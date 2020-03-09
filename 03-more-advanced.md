## More advanced

### Which tests are best?

Integration tests? Or unit tests? Acceptance tests?

As with so many aspects of our work, the answer is "it depends". Refer back
to [the introduction](01-introduction.md): we introduced the testing trophy
or pyramid, whichever you prefer. There's no hard-set value for how much to
have of any kind of test. Rather, we should examine what we want to _get out
of our test suites_:

1. Should tell us when something is broken
    - we only know when something is broken if our tests are run
        - slow tests are less likely to be run
            - so we want our tests to be as fast as possible
    - tests have to be reliable
        - when the pass, that must _definitely_ mean that tested code is good
            - this is why the red-green-refactor cycle is important
                - we must have a known, valid, failing condition _before_
                    implementing
        - when the fail, that must _definitely_ mean that tested code is not good
            - flaky tests _must not_ be ignored
                - they should be fixed to not flake
                - if it's impossible to prevent flaky results:
                    - mark with `[Retry]`
                        - this only works on NUnit assertion failures!
                        - you may need to wrap your entire test body in
                            `Assert.That(() => { /* test body here */ }, Throws.Nothing);`
                    - mark with `[Category]`
                        - (you'll probably need `[Retry]` too)
                        - ensure that there is a process which runs these categorised
                            tests
                        - mark as `[Explicit]` if the code is unlikely to change
                            - tests can be run by someone _meaning_ to change the code
                                under test
2. Should document what the system does
    - a stranger to our code should be able to figure out
        how the system works by traversing unit tests
        - requires that tests be simple, direct, well-named
3. Should have led us to the implementation
    - for TDD, we need incremental tests that are going to
        get us from "no implementation", to "works as expected"

Unit tests tick a lot of these boxes, particularly when well-written:
- fast
- simple
- accurate errors

However, Integration / Acceptance tests are equally valuable, because
they state a business case in broader terms (eg "customer should be able
to place an order").
- provide overall "documentation" of expected behavior
- slower to run
- necessary when certain boundaries can't be reliably mocked out
    - SQL engines
        - MySql vs SQL Server vs sqlite vs SQLCE
        - mocking out your data layer can hide runtime errors
            - reduces confidence in the tests
                - when people expect test suites to fail, either:
                    - the tests aren't run at all, or
                    - the tests are run, but when they fail, the response is`¯\_(ツ)_/¯`
    - External APIs
        - can be flaky
        - should be tests around expected input / output, not tests around
            _our_ system behavior
        - should be automated to guarantee that our mocked APIs are valid
    - Filesystem
        - invalid characters
        - speed bottlenecks
        - file-system limitations


### Randomised testing

There are some good reasons to use random values within tests:
- think less, test more
    - if you know that your code should handle any integer, a random one will do
- when the actual value isn't really that important
    - sometimes you need to set up a test with a customer, who has attributes
        which aren't pertinent to the test, eg
        - birthday
        - phone number
        - email address
    - rather let a randomising library do this for you
        - Javascript: [faker.js](https://www.npmjs.com/package/faker)
        - C#: [PeanutButter.RandomGenerators](https://www.nuget.org/packages/peanutbutter.randomgenerators)
- free fuzzing
    - random values are fed into your code under test
    - sometimes your tests may fail because of random values
        - often you just need to constrain the random values a bit
        - _sometimes_ you discover interesting flaws in your code (:
        
#### What to do when tests fail

Random values are random! If you get a test which randomly fails using random values:

##### [1] Add logging. 

First off, your assertions should be helping to find problems. Here are two
assertions proving the same fact, but one gives much better errors than the
other(s). Can you guess which?

```csharp
var collection = new List<int>() { 1, 2, 3 };
Expect(collection.IndexOf(4))
    .To.Be.Greater.Than(-1);
Expect(collection.Contains(4))
    .To.Be.True();
Expect(collection)
    .To.Contain.Exactly(1)
    .Equal.To(4);
```

If you guessed the last one in both cases, you'd be correct. Let's look
at messages you'd get back on failures:
- Expected -1 to be greater than -1
- Expected True, but got False
- Expected to find exactly 1 occurrence of 4 but found 0

Note that the last message, whilst still quite short, tells us a lot more
than the others:
- what we were looking for
- how many we were looking for
- how many were actually found

This is a simple example of information which isn't available from
simply asserting something is true or false from a condition you've
derived in your tests. However, if you _have to_ assist your assertions
library by "dumbing down" the result of a test to, eg, a boolean, you 
should make a failure clearer with a custom message. NExpect can be
given a custom message (or message generator) for any expectation.
I recommend using the generator, especially if the message generation
comes with a cost (like gathering information from the test context).

```csharp
var collection = new List<int>() { 1, 2, 3 };
var search = 4;
Expect(collection.Contains(search))
    .To.Be.True(
        () => $"Expected to find {4} in the collection:\n{string.Join(",", collection)}"
    );
```

##### [2] `[Repeat]`

Sporadic failures mean you're going to have to run the tests _until they fail_ to find
the failing conditions. Adding the `[Repeat]` attribute to a test will cause it to be
run until it fails:

```csharp
[Repeat(100)]
[Test]
public void ShouldNeverGet6()
{
    // Arrange
    // Act
    var number = GetRandomInt(); // ha! we'll get a 6 some time, for sure
    // Assert
    Expect(number)
        .Not.To.Equal(6, () => "We never expect to get 6!");
}
```
 
If you're still struggling to figure out the failure, it's time to add a block
of code which will only trigger when the test is about to fail, breakpoint in there
and debug tests with the `[Repeat]` attribute added. When you finally do hit that
breakpoint, rewind test execution a bit (probably to the start of the `// Act`) section,
and step through your code to figure out _wtf_ is going on.

```csharp
[Repeat(100)]
[Test]
public void ShouldPersistCustomerData()
{
    // Arrange
    var customer = GetRandom<Customer>();
    var sut = Create();
    // Act
    var id = sut.Persist(customer);
    // Assert
    var inDatabase = FindCustomerInDatabase(id);
    if (inDatabase.EmailAddress.Contains("invalid"))
    {
        Debugger.Break(); // depending on your tooling, this may not trigger, so add a breakpoint here too
    }
    Expect(inDatabase.EmailAddress)
        .Not.To.Contain("invalid");
}
```
        
Congratulations! perhaps you've found a bug in your production code?

#### Guiding randomisation

If you're using `PeanutButter.RandomGenerators` from your testing code, you may sometimes
come across a situation where the randomiser generates data that would never work within
your system. For example:

```csharp
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AgeInYears { get; set; }
}

[Test]
public void ShouldPersistCustomerData()
{
    // Arrange
    var customer = GetRandom<Customer>();
    var sut = Create();
    // Act
    var id = sut.Persist(customer);
    // Assert
    var persisted = FindCustomerById(id);
    // update our random customer to make assertions easier:
    customer.Id = id;
    Expect(persisted)
        .To.Deep.Equal(customer);
}
```

In the code above, the customer persistence code may insist that a customer
have an age > 0. However, _zero is a perfectly acceptable random integer value_.

The same system may also insist that a customer be at least 13, and not accept
insane values (let's say > 120).

Under the hood, `GetRandom<T>()` is using `PeanutButter.RandomGenerators.GenericBuilder<T1, T2>`
to do the heavy lifting. So at runtime, `GetRandom<T>()` is doing the following:
1. Look for an existing `GenericBuilder<T1, T2>`
    - where `T1` is the type of the builder (self-referential, to facilitate builder syntax
        where methods return a pointer to the instance of the builder)
    - `T2` is the type of the entity being built (in this case `Customer`)
    - First the current assembly is searched
    - Then all satellite assemblies
2. If no builder is found, one is generated for you
3. Whatever the result from above, it is cached so that the lookup / generation
    doesn't have to happen again
    
[1] gives you a loop-hole to intercept calls to `GetRandom<T>()` and guide the
generation of values. Let's say we want random customers to have ages >= 13 and <= 120. We
could add the following class to our test assembly:

```csharp
public class CustomerBuilder: GenericBuilder<CustomerBuilder, Customer>
{
    public override CustomerBuilder WithRandomProps()
    {
        return base.WithRandomProps() // randomise everything the "default" way
            .WithValidAge();
    }

    public CustomerBuilder WithValidAge()
    {
        return WithAge(GetRandomInt(13, 120));
    }

    public CustomerBuilder WithAge(int age)
    {
        return WithProp(o => o.Age = age);
    }
}
```

We can use this technique to work around other potential problems:
- random integers are 0-10 inclusive by default
    - if you need a large collection with unique integer ids, you can
        store a static id, and assign the next increment to each instance
        built by your custom builder
- perhaps we'd like human-readable names
    - random strings are quite random by default
- perhaps we'd like to fill collections on the object
    - GenericBuilder<T1, T2> _can_ do this for you, but doesn't
        by default because it opens a whole can of worms, especially
        with respect to parent-child relationships
- we may have an enum which includes, eg, an 'Unknown' value, which may not
    be something we want in most of our tests

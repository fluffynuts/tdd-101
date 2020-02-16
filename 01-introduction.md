## Introduction

### What is TDD?
Test Driven Development is a programming methodology where tests are written for expected
behavior from production code _before_ writing the production code.

Hence the tests _drive_ the development of the production code

### Why bother doing it?
There are few people who would argue on the benefit of having a good suite of unit tests
against production code, especially if those unit tests can be automatically run and trusted
to provide feedback of the correctness of the code under test.

Ok, so there _are_ a few people who would argue against a good set of automated tests.

On _rare_ occasions, they can have a point. For example, when you're writing proof-of-concept
code, or trying to get out a MVP (minimum viable product) to prove that your idea has merit
so that a client or investor will buy into it.

Whilst this can be a good time to skip the tests, the reality is that few "throw-away solutions"
are actually thrown away. Once you've proven your point, the client will not understand your
desire to start again, when you have something that's "so close to what we need".

Skipping the tests is a choice that can be made, but should not be taken lightly. Skipped
tests form technical debt for any project with an unknown or long-term lifespan.

The debate around TDD mostly stems around the question of _why the tests should be written
first_. It's an easy methodology to argue against -- it seems counter-intuitive, it's
not easy, and, well, there's plenty of "expert programmers" who tell you that they don't do
it and that the whole process is rubbish.

But there are some good reasons:

1. By writing a test first, you are clearly defining the behavior that you'd like the system
    to have. All too often, we want to dive into the code, without first planning out what
    we'd really like to accomplish. I'm not talking about planning every nook and cranny
    of the resultant system -- indeed, I think that doing so is a waste of time and resources,
    as backed up by the number of times I've personally seen a fully-planned project take a
    complete turn away from the final projection in response to customer needs; alternatively,
    I've seen projects that stick to the plan 100% fail at launch because the plan is no
    longer relevant.

    But what we really _do_ want to do, is have a clear idea of _why_ we're about to write
    even one line of code.

    Writing a test not only forces you to think that through -- it also forces you to express
    that in terms that someone else can read, with an artifact that will benefit you later:
2. By writing the test first, we can easily validate when we have written sufficient code
    to meet the requirements we established earlier. And:
3. We now have an artifact which we can run via automation to verify that the code we've written
    conforms to the requirements _at any point in the future_

### The TDD Cadence

The term "Cadence" refers to a rhythmic flow of a sequence of sounds or words, but can be
applied to any rhythmic activity. When programming test-first, one enters a cadence:

#### Red
A common misconception about TDD is that we should write _all_ the tests first.

This is a place at which many people, upon trying this approach, declare TDD impractical.

The truth though, is that we should write exactly _one_ test.

In addition, we should _run_ this test, _and it **must** fail_. A purist would state here
that a compilation failure also counts as "Red" -- having a test which describes the required
behavior of the system when the API doesn't exist yet is a good step, and can be used to
drive the design of that API, but honestly, you've only left the Red phase of the TDD cadence
once you've written, compiled and run your single test _and it has failed_.

##### What if the test doesn't fail? Who cares? The production code works then, right?

_NO_

If you wrote a test which immediately went green, you have no proof that the test you wrote
is valid. Here's an example:


```csharp
[TestFixture]
public class TestCalculator
{
    [TestFisture]
    public class Add
    {
        [Test]
        public void ShouldAddTwoNumbers()
        {
            // Arrange
            var sut = new Calculator();
            // Act
            var resut = sut.Add(2, 2);
            // Assert
            Expect(result)
                .To.Equal(4);
        }
    }
}

public class Calculator
{
    public int Add(int a, int b)
    {
        return a + a;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }
}
```

The `Calculator` class is clearly buggy. However, the test passes.

The example above should also expose another issue: one test isn't enough. It's quite
possible to have written the test above first, and still have written the buggy code.

However, if you write the test _after_ the code, and it goes green immediately, you have
no idea if the code is broken or the test is broken. If you've absolutely _had_ to write
the code first (eg if figuring out a library api you're using), you should comment
out the passing code to ensure that your test fails without that code being there.

#### Green
Next comes the fun part! Solving for the test! The idea here is to write the _minimum code
necessary to solve the requirements of the test_.

This _doesn't_ mean you should write the most obscure, shortest code necessary. You still
need to subscribe to good coding standards:
- well-named variables
- clear flow
- one statement per line
- whatever else your team subscribes to

It just means that you should resist the urge to solve the entire requirements of a class
after writing the first test. The reason why should be self-evident: as above, if we solve
everything _now_, before we have a test, then when we write tests and they are immediately
green, they don't verify that we have the correct requirements or the correct response.

#### Refactor
This step is often skipped, not just in TDD cicles, but generally. We are so excited to bang
out the solution and we _know exactly how to get there_! So why wait? Quicker is better, yeah?

Refactoring refers to observing the code in its current state and testing if we could write
it better
- perhaps something could be better-named
- perhaps a block of code could be pulled out into a well-named method
    - a really good indicator of this is if you've added a comment to explain
        what's happening, or, if upon attempting to explain the code to someone else,
        you can point to a few lines of code and explain what's happening there
- perhaps there's even a whole class you can pull out
    - is the class you're working on starting to do a bunch of things? The "S" in SOLID
        refers to "Single Responsibility", basically boiling down to the unix philosophy
        of building small programs which do one thing well and which can talk to each other.
- lastly, perhaps there's a performance optimisation you can make here
    - beware early optimisation
    - code which reads well is worth more than code which runs marginally faster
    - optimisation should be left later in the code-cycle, rather than done earlier as
        prematuve optimisation often leads to having to make sub-optimal code choices later.

The best bit about TDD is that you have so much freedom at this point -- you are free to
explore any refactoring you think might be worthwhile. You can rip out the entire internals
of the production code an literally start again, from scratch. This freedom has been afforded
to you because you have a good suite of automated tests you can run over the production code
to verify if your changes still uphold the requirements.

I've been lucky enough to have the freedom to completely restart a project, more than once,
by simply keeping the test suite and throwing away the code.

### The testing pyramid
### TDD "gears"
    - low gear
        - when you're new at TDD
        - when the problem space isn't well known
    - high gear
        - when you know your way around quite well
        - when the problem space is quite well known
### Unit testing in .NET with NUnit
    - Running tests
        - Rider / Resharper
        - Command line
    - [TestFixture]
    - [Test]
    - [TestCase]
    - [TestCaseSource]
    - Setup and teardown
    - [Ignore] vs [Explicit]


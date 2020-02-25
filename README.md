# TDD 101
(this document should be split up at some point)

## Introduction
### Summary:
- What is TDD?
- Why bother doing it?
- The testing pyramid
    - unit tests vs integration tests
- The TDD cadence: Red, Green, Refactor
- TDD "gears"
    - low gear
        - when you're new at TDD
        - when the problem space isn't well known
    - high gear
        - when you know your way around quite well
        - when the problem space is quite well known
- Unit testing in .NET with NUnit
    - Running tests
        - Rider / Resharper
        - Command line
    - [TestFixture]
    - [Test]
    - [TestCase]
    - [TestCaseSource]
    - Setup and teardown
    - [Ignore] vs [Explicit]

[full notes](01-introduction.md)

Workshop: [DateTimeProvider](workshops/01-datetime-provider/readme.md)

# Diving in
- Anatomy of a “good test”
    - descriptive name
        - Given / When / Then
    - SHOULD
        - inspired by Javascript testing
        - using sub-fixtures in NUnit
    - Tells you exactly what broke when it fails
    - A(V)AA
        - Arrange
            - set up everything required to have your test run
        - Validate (optional)
            - perform any initial validations that check that the test environment is
                correctly set up
        - Act
            - perform the action to be tested
            - ideally only one line
        - Assert
            - assert that the correct result was received / behavior was enacted
            - ideally few asserts for a focused test
            - if you find you're doing lots of asserts, rather copy/paste the
                test and split the asserts up. Rename each variant with what is
                _actually_ being tested
    - Assertions
        - NUnit Assert
        - NExpect
    - as few layers as possible (integration → unit)
    - self-contained
    - naming
        - SUT
        - variables which decide flow
            - “customer1”, “customer2” vs “inactiveCustomer”, “activeCustomer”
    - factory function to create SUT
        - DRY
        - future-proofing your tests

[full notes](02-diving-in.md)

Workshop: [String Calculator](workshops/02-string-calculator/readme.md)

## More advanced
- Which tests are best? Integration or Unit?
    - Strive towards unit test
        - faster
        - simpler
        - more accurate errors
    - Integration tests are also valuable
        - still try to keep the scope as small as possible
        - validate that code works against dependencies
            - SQL engines
            - File systems
            - Remote APIs
                - can be brittle
                - mark with [Retry]
                    - Only works on NUnit assertion failures!
                - tag with a [Category]
                - mark [Explicit(“with a reason why”)]
    - Random values
        - think less, test more
        - free fuzzing
        - what to do when tests fail
            - random values are random: make sure the range of randomness is valid
            - congratulations! perhaps you've found a bug in your production code?

Workshop: [CRUD](workshops/03-crud/readme.md)

## Testing more complex systems
- Finding boundaries
    - Interface all the things!
- Gearing up
    - Fakes, Mocks and Stubs
        - what's the difference? does it really matter? (short answer: no; longer answer: chances are good you're mocking and stubbing at the same time, so, no.)
            - more here: https://www.martinfowler.com/articles/mocksArentStubs.html
        - why?
        - substitutes with NSubstitute
    - Test arenas
        - when you have to set up a lot of stuff to get a test working
        - prefer an arena over state in the test fixture
            - prevents test interactions

Workshop: [WebApi Controller](workshops/04-webapi-controller/readme.md)
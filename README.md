# TDD 101
(this document should be split up at some point)

- What is TDD?
- Why bother doing it?
- The testing pyramid
    - unit tests vs integration tests
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

Workshop: [DateTimeProvider](workshops/01-datetime-provider/readme.md)

- Anatomy of a “good test”
    - descriptive name
        - Given / When / Then
            - → SHOULD
            - inspired by Javascript testing
            - using sub-fixtures in NUnit
    - A(P)AA
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

Workshop: [String Calculator](workshops/02-string-calculator/readme.md)

- Integration or Unit?
    - Strive towards unit test
        - faster
        - simpler
        - more accurate errors
    - Integration tests are valuable
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

- Gearing up
    - Fakes, Mocks and Stubs
        - what's the difference? does it really matter? (short answer: no; longer answer: chances are good you're mocking and stubbing at the same time, so, no.)
            - more here: https://www.martinfowler.com/articles/mocksArentStubs.html
        - why?
        - substitutes with NSubstitute
    - Test arenas

Workshop: [WebApi Controller](workshops/04-webapi-controller/readme.md)
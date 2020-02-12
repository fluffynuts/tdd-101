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

Workshop: [DateTimeProvider](workshops/01-datetime-provider.md)

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

Workshop: [String Calculator](workshops/02-string-calculator.md)

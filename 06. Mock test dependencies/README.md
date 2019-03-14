Mock test dependencies
======================

When writing unit tests, you'll want to mock out dependencies so you can focus on the unit under test. Unit tests should always be simpler than the code they're testing.

In this example we use `MoQ` to mock dependencies.  `AutoMocker` makes an IoC container full of mocks so tests don't change when the class changes for irrelevant reasons.  `FluentAssertions` makes assert statements really legible.

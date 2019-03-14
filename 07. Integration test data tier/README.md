Integration Test Data tier
==========================

It's common to unit test business services, but unit testing data access doesn't make sense. The purpose of the repository pattern is the boundary between code and data storage, so testing the repositories should validate the code can round-trip data. Avoid mocking in these tests, and avoid alternate data stores (in-memory, alternate providers) that may give you a false sense of security.

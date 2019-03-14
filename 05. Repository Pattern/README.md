Repository Pattern
==================

The repository pattern creates stateless services that map between a POCO and a table in the data store.  This makes it easy to audit database usage.  These repositories are the only references to the Data Context and the database.  Repositories should avoid business logic, working only to minimize returned fields and records to limit bandwidth consumption.

In contrast, the Unit of Work pattern has a stateful object that represents a database transaction.  Load up many queries, then call a single "Save" or "Commit" method to persist all things at once.  EntityFramework uses the Unit of Work pattern, so one doesn't need a Unit of Work wrapper around it.


Sample
------

Look at the Repository folder for an example of these repositories.  Look to the consuming projects to see how repositories are used.

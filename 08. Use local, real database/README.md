Use local, real database
========================

Often we keep a central database for developers. This can easily lead to collisions.

Imagine you start up your task each morning by opening Visual Studio, then you open the shared network drive, and open the solution.  Then I come in and open Visual Studio, open the same shared network drive, and open the same solution.  This is exactly what we do with shared databases.

Storage is cheap now, and migration tools are pleantiful.  There is no good reason not to give each developer her own database.


Also avoid developing or testing with different databases such as Entity Framework's in-memory database or SQLite.  The differences will likely bite you at the most inopportune moments.

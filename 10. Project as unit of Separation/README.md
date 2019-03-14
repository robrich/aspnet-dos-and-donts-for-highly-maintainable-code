Project as unit of Separation
=============================

Though projects are technically the unit of deployment, they can be really useful for separating tiers or units of functionality to ensure you don't have cross-dependencies and each unit is contained.

Granted, it's possible to go overboard here. Avoid creating a project for just a few files. If you have more than a dozen projects, you've probably over-abstracted.

Sample
------

In this sample, there's a data access tier (the definition of the db context), a repository tier (the only consumer of this db context), a service tier, and a web tier. Entities and libraries are also defined in separate projects that could easily be shared with other clients like Xamarin or UWP apps.

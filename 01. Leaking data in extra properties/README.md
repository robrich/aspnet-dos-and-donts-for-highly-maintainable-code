Leaking data in Extra Properties
================================

It's really easy to misuse a Data Access entity as a View Model or as a Post Request model, and accidentally leak information.


Sample
------

The `BadController` has methods that we expect to function in specific ways, but what happens when we call these AJAX methods in unexpected ways?  We can set properties you didn't expect, and we can harvest more information than you want.

Instead, copy the properties you need to/from a ViewModel and use this publicly.  See `GoodController` for a good example using [AutoMapper](https://automapper.org/).

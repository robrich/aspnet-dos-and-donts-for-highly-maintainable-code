`[ApiController]` Attribute
===========================

Adding `[ApiController]` on a class or method adds a lot of conventions appropriate for APIs:

- automatic `ViewState` validation
- inferred attribute source: automatic `[FromBody]` attribute
- `ActionResult<T>` response for better Swagger integration


## See also:

- https://kimsereyblog.blogspot.com/2018/08/apicontroller-attribute-in-asp-net-core.html
- https://www.strathweb.com/2018/02/exploring-the-apicontrollerattribute-and-its-features-for-asp-net-core-mvc-2-1/
- https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-2.2#annotation-with-apicontroller-attribute

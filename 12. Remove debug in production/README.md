Remove `debug=true` from web.config
===================================

The easiest way to kill the performance of your ASP.NET Framework app is to leave this line in web.config:

`<compilation debug="true" ...`

## See warnings from:

- [Scott Guthrie](https://weblogs.asp.net/scottgu/442448)
- [Scott Hanselman](https://www.hanselman.com/blog/MostCommonASPNETSupportIssuesReportingFromDeepInsideMicrosoftDeveloperSupport.aspx)
- [Tess Ferrandez](https://blogs.msdn.microsoft.com/tess/2006/04/12/asp-net-memory-if-your-application-is-in-production-then-why-is-debugtrue/)
- [Nikos Kantzelis](https://dotnetstories.wordpress.com/2007/10/13/the-worst-5-mistakes-in-the-webconfig-file/)


When `debug=true` is left in, Scott Gu notes:

- The compilation of ASP.NET pages takes longer (since some batch optimizations are disabled)
- Code can execute slower (since some additional debug paths are enabled)
- Much more memory is used within the application at runtime
- Scripts and images are not cached

Scott Hanselman adds:

- Overrides request execution timeout making it effectively infinite
- Disables both page and JIT compiler optimizations
- Leads to excessive memory usage by the CLR for debug information tracking
- Turns off batch compilation of dynamic pages, leading to 1 assembly per page.
- For VB.NET code, leads to excessive usage of WeakReferences (used for edit and continue support).


## In ASP.NET Core, this is done with this environment variable:

`ASPNETCORE_ENVIRONMENT=Production`


## Solution

Solve this by publishing from Visual Studio in Release mode or better still, create a DevOps pipeline that builds in Release mode.

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilters.Filters
{
	public class HelloActionFiltersAttribute : ActionFilterAttribute
	{

		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			// before regular method
			Console.WriteLine($"Before {context.HttpContext.Request.Path}");
			Console.WriteLine($"Calling {context.ActionDescriptor.RouteValues["controller"]}.{context.ActionDescriptor.RouteValues["action"]}");

			// do the regular method
			var result = await next();

			// after regular method
			Console.WriteLine($"Finished calling {context.ActionDescriptor.RouteValues["controller"]}.{context.ActionDescriptor.RouteValues["action"]}");
		}

		public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			// before view rendering
			string viewName = null;
			ViewResult view = context.Result as ViewResult;
			if (view != null) {
				viewName = view.ViewName;
			}
			if (string.IsNullOrEmpty(viewName)) {
				viewName = context.ActionDescriptor.RouteValues["action"];
			}

			Console.WriteLine($"Rendering {viewName}");

			// render the view
			var result = await next();

			// after view rendering
			Console.WriteLine($"Finished rendering {viewName}");
			Console.WriteLine($"After {context.HttpContext.Request.Path}");
		}

	}
}

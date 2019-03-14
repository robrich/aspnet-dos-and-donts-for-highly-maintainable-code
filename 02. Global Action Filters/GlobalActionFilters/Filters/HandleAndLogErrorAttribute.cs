using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GlobalActionFilters.Filters
{
	public class HandleAndLogErrorAttribute : ExceptionFilterAttribute
	{

		public override void OnException(ExceptionContext context)
		{
			Exception ex = context.Exception;
			if (ex == null) {
				return;
			}

			DoSomeLogging(ex, context.ActionDescriptor.RouteValues["controller"], context.ActionDescriptor.RouteValues["action"]);

			context.ExceptionHandled = true;
			context.Result = new ViewResult {
				ViewName = "Error"
			};
		}

		private void DoSomeLogging(Exception ex, string controller, string action)
		{
			// TODO: log to Serilog
		}
	}
}

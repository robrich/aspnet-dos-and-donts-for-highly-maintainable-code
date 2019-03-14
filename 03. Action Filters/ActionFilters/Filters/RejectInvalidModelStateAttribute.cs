using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace ActionFilters.Filters
{
	public class RejectInvalidModelStateAttribute : ActionFilterAttribute
	{

		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			// before regular method
			if (!context.ModelState.IsValid) {
				context.Result = new BadRequestObjectResult(context.ModelState);
				return;
			}

			// do the regular method
			var result = await next();
		}

	}
}

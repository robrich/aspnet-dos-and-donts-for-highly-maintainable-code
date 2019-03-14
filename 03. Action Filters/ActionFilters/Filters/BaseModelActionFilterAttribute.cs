using ActionFilters.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace ActionFilters.Filters
{
	public class BaseModelActionFilterAttribute : ActionFilterAttribute
	{

		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			// before regular method

			// do the regular method
			var result = await next();

			// after regular method
			Controller controller = context.Controller as Controller;
			BaseModel model = controller?.ViewData?.Model as BaseModel;
			if (model != null) {
				model.RequestTime = DateTime.UtcNow;
			}
		}

	}
}

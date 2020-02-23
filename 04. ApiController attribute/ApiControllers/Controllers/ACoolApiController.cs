using GlobalActionFilters.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlobalActionFilters.Controllers
{
	// see https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-2.2#annotation-with-apicontroller-attribute
	// see https://www.strathweb.com/2018/02/exploring-the-apicontrollerattribute-and-its-features-for-asp-net-core-mvc-2-1/

	[Route("api/[controller]")]
	[ApiController]
	public class ACoolApiController : Controller
	{

		[HttpPost("")]
		public ActionResult<ResponseViewModel> PostTheModel(RequestViewModel model)
		{
			// either is fine:
			/*
			return new ResponseViewModel {
				Message = $"Success: {model.RequiredString}"
			};
			*/
			// *
			return Ok(new ResponseViewModel {
				Message = $"Success: {model.RequiredString}"
			});
			//*/
		}

	}
}

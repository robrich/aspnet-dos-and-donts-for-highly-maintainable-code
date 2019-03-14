using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ActionFilters.Models;
using ActionFilters.Filters;
using System;

namespace ActionFilters.Controllers
{
	// can be on a class or a method: [HelloActionFilters]
	public class HomeController : Controller
	{
		// can be on a class or a method:
		[HelloActionFilters]
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult ThrowException()
		{
			throw new Exception("go boom");
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

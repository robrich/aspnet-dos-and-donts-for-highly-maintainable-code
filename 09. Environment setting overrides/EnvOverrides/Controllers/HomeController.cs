using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EnvOverrides.Models;

namespace EnvOverrides.Controllers
{
	public class HomeController : Controller
	{
		private readonly Settings settings;

		public HomeController(Settings settings)
		{
			this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
		}

		public IActionResult Index()
		{
			return View(this.settings);
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

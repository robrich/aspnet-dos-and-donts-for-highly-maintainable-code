using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Entity;
using RepositoryPattern.Repository;
using RepositoryPattern.Service;
using RepositoryPattern.Web.Models;

namespace RepositoryPattern.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ITodoRepository todoRepository;
		private readonly ITodoService todoService;

		public HomeController(ITodoRepository todoRepository, ITodoService todoService)
		{
			this.todoRepository = todoRepository ?? throw new System.ArgumentNullException(nameof(todoRepository));
			this.todoService = todoService ?? throw new System.ArgumentNullException(nameof(todoService));
		}

		public async Task<IActionResult> Index()
		{
			var allTodos = (await this.todoRepository.GetAll()) ?? new List<Todo>();
			return View(allTodos);
		}

		[HttpPost]
		public IActionResult Save(Todo todo)
		{
			if (!ModelState.IsValid) {
				return Json(this.ModelState); // TODO: make a better fail model
			}
			this.todoRepository.Save(todo);
			return Json(new { Success = true });
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

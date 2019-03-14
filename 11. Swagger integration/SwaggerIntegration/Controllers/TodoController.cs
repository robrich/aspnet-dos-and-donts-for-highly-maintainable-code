using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SwaggerIntegration.Models;
using SwaggerIntegration.Services;

namespace SwaggerIntegration.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class TodoController : ControllerBase
	{
		private readonly ITodoRepository todoRepository;

		public TodoController(ITodoRepository todoRepository)
		{
			this.todoRepository = todoRepository ?? throw new ArgumentNullException(nameof(todoRepository));
		}

		[HttpGet]
		[ProducesResponseType(typeof(List<Todo>), 200)]
		public ActionResult<IEnumerable<Todo>> Get()
		{
			return this.todoRepository.GetAll();
		}

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(Todo), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public ActionResult<Todo> Get(int id)
		{
			Todo todo = todoRepository.GetById(id);
			if (todo != null) {
				return todo;
			} else {
				return NotFound();
			}
		}

		[HttpPost]
		[ProducesResponseType(typeof(Todo), 201)]
		[ProducesResponseType(typeof(ValidationProblemDetails), 400)]
		public ActionResult<Todo> Post(Todo model)
		{
			model.Id = 0;
			todoRepository.Save(model);
			return CreatedAtAction("Get", new { id = model.Id }, model);
		}

		[HttpPut("{id}")]
		[ProducesResponseType(typeof(Todo), 200)]
		[ProducesResponseType(typeof(ValidationProblemDetails), 400)]
		[ProducesResponseType(typeof(void), 404)]
		public ActionResult<Todo> Put(int id, Todo model)
		{
			Todo existing = this.todoRepository.GetById(id);
			if (existing == null) {
				return NotFound();
			}

			model.Id = id;
			todoRepository.Save(model);

			return model;
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(typeof(Todo), 200)]
		public ActionResult Delete(int id)
		{
			todoRepository.Delete(id);
			return Ok();
		}

	}
}

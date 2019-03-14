using LeakingData.Models;
using LeakingData.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LeakingData.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BadController : ControllerBase
	{
		private readonly IUserRepository userRepository;

		public BadController(IUserRepository userRepository)
		{
			this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
		}

		[HttpGet("{id}")]
		public ActionResult<User> GetById(int id)
		{
			User user = userRepository.GetById(id);

			if (user == null) {
				return NotFound();
			}

			return user;
		}

		[HttpPost("{id}")]
		public ActionResult<User> Save(User model)
		{
			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			}

			userRepository.Save(model);

			return this.Ok(model);
		}

	}
}

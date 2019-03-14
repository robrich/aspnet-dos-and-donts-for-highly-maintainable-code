using AutoMapper;
using LeakingData.Models;
using LeakingData.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LeakingData.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class GoodController : ControllerBase
	{
		private readonly IUserRepository userRepository;
		private readonly IMapper mapper;

		public GoodController(IUserRepository userRepository, IMapper mapper)
		{
			this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
			this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		[HttpGet("{id}")]
		public ActionResult<UserProfileEditViewModel> GetById(int id)
		{
			var user = userRepository.GetById(id);

			if (user == null) {
				return NotFound();
			}

            #region left-right code
            /*
            UserProfileEditViewModel model = new UserProfileEditViewModel {
                Id = user.Id,
                FirstName = user.FirstName,
                ...
            }
            */
            #endregion

            UserProfileEditViewModel model = mapper.Map<UserProfileEditViewModel>(user);

			return Ok(model);
		}

		[HttpPost("{id}")]
		public ActionResult<UserProfileEditViewModel> Save(UserProfileSaveViewModel model)
		{
			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			}

			User user = userRepository.GetById(model.Id);
			mapper.Map(model, user);
			userRepository.Save(user);

			UserProfileEditViewModel result = mapper.Map<UserProfileEditViewModel>(user);

			return Ok(result);
		}

	}
}

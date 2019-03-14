using AutoMapper;
using LeakingData.Models;

namespace LeakingData.Services
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<User, UserProfileEditViewModel>();
			CreateMap<UserProfileSaveViewModel, User>()
				.ForMember(t => t.Username, exp => exp.Ignore())
				.ForMember(t => t.Password, exp => exp.Ignore())
				.ForMember(t => t.AccountBalance, exp => exp.Ignore());
		}
	}
}

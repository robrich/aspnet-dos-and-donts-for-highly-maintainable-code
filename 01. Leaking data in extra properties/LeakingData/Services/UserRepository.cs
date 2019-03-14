using LeakingData.Models;

namespace LeakingData.Services
{
	public interface IUserRepository
	{
		User GetById(int id);
		void Save(User user);
	}
	public class UserRepository : IUserRepository
	{
		private static User fakeDatabase = new User {
			Id = 7,
			Username = "robrich",
			Password = "password",
			FirstName = "Rob",
			LastName = "Richardson",
			AccountBalance = 500
		};

		public User GetById(int id)
		{
			return fakeDatabase;
		}

		public void Save(User user)
		{
			fakeDatabase = user;
		}

	}
}

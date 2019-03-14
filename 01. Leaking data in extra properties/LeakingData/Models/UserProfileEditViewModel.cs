namespace LeakingData.Models
{
	public class UserProfileEditViewModel
	{

		// We're not leaking the password or account balance on get requests

		public int Id { get; set; }
		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}

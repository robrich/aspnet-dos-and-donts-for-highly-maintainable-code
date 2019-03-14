using System.ComponentModel.DataAnnotations;

namespace LeakingData.Models
{
	public class UserProfileSaveViewModel
	{
		public int Id { get; set; }

		// These are the only properties you can change through the API

		[Required]
		[StringLength(20)]
		public string FirstName { get; set; }
		[Required]
		[StringLength(50)]
		public string LastName { get; set; }
	}
}

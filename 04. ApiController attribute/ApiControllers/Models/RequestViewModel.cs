using System.ComponentModel.DataAnnotations;

namespace GlobalActionFilters.Models
{
	public class RequestViewModel
	{
		[Required]
		[StringLength(20, MinimumLength = 5)]
		public string RequiredString { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerIntegration.Models
{
	public class Todo
	{

		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(200, MinimumLength = 5)]
		public string Task { get; set; }

		public TaskStatus TaskStatus { get; set; }

		public bool Hidden { get; set; }

	}
}

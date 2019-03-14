using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectPerUnit.Entity
{
	[Table("Todo")]
	public class Todo : IEntity
	{
		[Required]
		[StringLength(100)]
		public string Task { get; set; }
		[Column("TaskStatusId")]
		public TaskStatus TaskStatus { get; set; }
	}
}

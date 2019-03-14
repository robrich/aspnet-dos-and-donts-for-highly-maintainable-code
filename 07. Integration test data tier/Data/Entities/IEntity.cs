using System;
using System.ComponentModel.DataAnnotations;

namespace IntegrationTestDataTier.Data.Entity
{
	// Used like an interface, but an abstract class so we don't need to `where TEntity : IEntity, new()`
	public abstract class IEntity
	{
		[Key]
		public virtual int Id { get; set; }

		public DateTime CreateDate { get; set; }
		public DateTime ModifyDate { get; set; }

		public bool IsNew()
		{
			return Id < 1;
		}
	}
}

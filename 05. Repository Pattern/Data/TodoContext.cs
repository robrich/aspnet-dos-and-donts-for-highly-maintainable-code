using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Entity;

namespace RepositoryPattern.Data
{
	public interface ITodoContext
	{
		void DefeatChangeTracking<TEntity>(TEntity entity) where TEntity : IEntity;
		int SaveChanges();
		// purely for the base repository
		DbSet<TEntity> GetTable<TEntity>() where TEntity : IEntity;
		DbSet<Todo> Todos { get; set; }
	}

	public class TodoContext : DbContext, ITodoContext
	{
		public TodoContext(DbContextOptions<TodoContext> options) : base(options)
		{
		}

		public void DefeatChangeTracking<TEntity>(TEntity entity) where TEntity : IEntity
		{
			this.Attach(entity).State = EntityState.Modified;
		}

		public DbSet<TEntity> GetTable<TEntity>() where TEntity : IEntity
		{
			return this.Set<TEntity>();
		}

		public DbSet<Todo> Todos { get; set; }

	}
}

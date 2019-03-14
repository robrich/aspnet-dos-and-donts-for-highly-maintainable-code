using IntegrationTestDataTier.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationTestDataTier.Data.Repositories
{
	public interface IRepository<TEntity> where TEntity : IEntity
	{
		int Save(TEntity entity);
		Task<List<TEntity>> GetAll();
		Task<TEntity> GetById(int id);
	}

	public class Repository<TEntity> : IRepository<TEntity> where TEntity : IEntity
	{
		protected ITodoContext todoContext { get; }

		public Repository(ITodoContext todoContext)
		{
			this.todoContext = todoContext ?? throw new ArgumentNullException(nameof(todoContext));
		}

		public int Save(TEntity entity)
		{
			DbSet<TEntity> table = this.todoContext.GetTable<TEntity>();
			entity.ModifyDate = DateTime.UtcNow;
			if (entity.IsNew()) {
				entity.CreateDate = entity.ModifyDate;
				table.Add(entity);
			} else {
				table.Attach(entity);
				this.todoContext.DefeatChangeTracking(entity);
			}
			return this.todoContext.SaveChanges();
		}

		public virtual async Task<List<TEntity>> GetAll()
		{
			DbSet<TEntity> table = this.todoContext.GetTable<TEntity>();
			return await (
				from t in table
				select t
			).ToListAsync();
		}

		public virtual async Task<TEntity> GetById(int id)
		{
			if (id < 1) {
				return null;
			}
			DbSet<TEntity> table = this.todoContext.GetTable<TEntity>();
			return await (
				from t in table
				where t.Id == id
				select t
			).FirstOrDefaultAsync();
		}

	}
}

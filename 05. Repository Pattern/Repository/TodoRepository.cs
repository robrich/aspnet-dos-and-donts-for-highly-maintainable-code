﻿using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskStatus = RepositoryPattern.Entity.TaskStatus;

namespace RepositoryPattern.Repository
{
	public interface ITodoRepository : IRepository<Todo>
	{
		Task<List<Todo>> GetByStatus(TaskStatus status);
	}

	public class TodoRepository : Repository<Todo>, ITodoRepository
	{

		public TodoRepository(ITodoContext todoContext) : base(todoContext)
		{
		}

		public override async Task<List<Todo>> GetAll()
		{
			return (
				from t in await base.GetAll()
				orderby t.Task
				select t
			).ToList();
		}

		public async Task<List<Todo>> GetByStatus(TaskStatus status)
		{
			return await (
				from t in this.todoContext.Todos
				where t.TaskStatus == status
				orderby t.Task
				select t
			).ToListAsync();
		}

	}
}

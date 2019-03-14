using SwaggerIntegration.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwaggerIntegration.Services
{
	public interface ITodoRepository
	{
		void Save(Todo todo);
		List<Todo> GetAll();
		Todo GetById(int id);
		void Delete(int id);
	}

	public class TodoRepository : ITodoRepository
	{
		private static List<Todo> database = new List<Todo> {
			new Todo {
				Id = 1,
				Task = "First Task",
				TaskStatus = TaskStatus.Open
			}
		};

		public void Save(Todo todo)
		{
			if (todo.Id < 1) {
				todo.Id = 1 + (
					from t in database
					orderby t.Id descending
					select t.Id
				).FirstOrDefault();
			} else {
				Todo existing = database.FirstOrDefault(t => t.Id == todo.Id);
				if (existing != null) {
					database.Remove(existing);
				}
			}
			database.Add(todo);
		}

		public List<Todo> GetAll()
		{
			return (
				from t in database
				orderby t.Task
				select t
			).ToList();
		}

		public Todo GetById(int id)
		{
			return (
				from t in database
				where t.Id == id
				select t
			).FirstOrDefault();
		}

		public void Delete(int id)
		{
			Todo existing = database.FirstOrDefault(t => t.Id == id);
			if (existing != null) {
				database.Remove(existing);
			} else {
				// the goal is to delete it and it's gone, success
			}
		}

	}
}

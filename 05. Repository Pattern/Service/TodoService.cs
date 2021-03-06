﻿using RepositoryPattern.Entity;
using System.Collections.Generic;

namespace RepositoryPattern.Service
{
	public interface ITodoService
	{
		List<Todo> SetAllToStatus(List<Todo> todos, TaskStatus status);
	}

	public class TodoService : ITodoService
	{

		public List<Todo> SetAllToStatus(List<Todo> todos, TaskStatus status)
		{
			if (todos == null) {
				return todos;
			}
			todos.ForEach(t => t.TaskStatus = status);

			return todos;
		}

	}
}

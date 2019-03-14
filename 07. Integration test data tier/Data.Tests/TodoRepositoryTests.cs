using FluentAssertions;
using IntegrationTestDataTier.Data.Entity;
using IntegrationTestDataTier.Data.Repositories;
using IntegrationTestDataTier.Data.Tests.Fixtures;
using System;
using System.Threading.Tasks;
using Xunit;
using TaskStatus = IntegrationTestDataTier.Data.Entity.TaskStatus;

namespace IntegrationTestDataTier.Data.Tests
{
	public class TodoRepositoryTests : IClassFixture<DatabaseFixture>
	{
		private readonly DatabaseFixture fixture;

		public TodoRepositoryTests(DatabaseFixture fixture)
		{
			this.fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
		}

		[Fact]
		public async Task GetById_Invalid_ReturnsNull()
		{

			// Arrange
			int todoId = -1;

			// Act
			TodoRepository repo = fixture.GetService<TodoRepository>();
			var actual = await repo.GetById(todoId);

			// Assert
			actual.Should().BeNull();

		}

		[Fact]
		public async Task CanCrud()
		{
			string newTaskName = Guid.NewGuid().ToString("N");
			string changedTaskName = Guid.NewGuid().ToString("N");

            int id = Add(newTaskName);
            Todo gotten = await ValidateAdd(id, newTaskName);
            ChangeData(id, gotten.CreateDate, changedTaskName);
            await ValidateChange(id, changedTaskName);
		}

        private int Add(string newTaskName)
        {

            // Arrange
            Todo created = new Todo
            {
                Task = newTaskName,
                ModifyDate = DateTime.MinValue,
                TaskStatus = TaskStatus.Open,
            };

            // Act
            TodoRepository repo = fixture.GetService<TodoRepository>();
            int saveCount = repo.Save(created);
            repo = null;

            // Assert
            created.Id.Should().BeGreaterThan(0, $"Failed to save successfully, id: {created.Id}");
            saveCount.Should().Be(1);

            return created.Id;
        }

        private async Task<Todo> ValidateAdd(int id, string newTaskName)
        {

            // Act
            var repo = fixture.GetService<TodoRepository>();
            Todo gotten = await repo.GetById(id);

            // Assert
            gotten.Should().NotBeNull();
            gotten.Task.Should().Be(newTaskName);
            gotten.TaskStatus.Should().Be(TaskStatus.Open);
            gotten.ModifyDate.Should().BeAfter(DateTime.MinValue);

            return gotten;
        }

        private void ChangeData(int id, DateTime createDate, string changedTaskName)
        {

            // Arrange
            Todo changed = new Todo
            {
                Id = id,
                CreateDate = createDate,
                ModifyDate = DateTime.MinValue,
                Task = changedTaskName,
                TaskStatus = TaskStatus.Completed
            };

            // Act
            var repo = fixture.GetService<TodoRepository>();
            var saveCount = repo.Save(changed);

            // Assert
            saveCount.Should().Be(1);

        }

        private async Task ValidateChange(int id, string changedTaskName)
        {

            // Act
            var repo = fixture.GetService<TodoRepository>();
            var gotten = await repo.GetById(id);

            // Assert
            gotten.Should().NotBeNull();
            gotten.Task.Should().Be(changedTaskName);
            gotten.TaskStatus.Should().Be(TaskStatus.Completed);
            gotten.ModifyDate.Should().BeAfter(DateTime.MinValue);

        }

    }
}

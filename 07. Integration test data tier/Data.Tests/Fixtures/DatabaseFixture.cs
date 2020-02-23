using System;
using IntegrationTestDataTier.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTestDataTier.Data.Tests.Fixtures
{
	public class DatabaseFixture : IDisposable
	{
		private readonly ServiceProvider serviceLocator;

		public DatabaseFixture()
		{
			IConfiguration configuration = GetConfiguration();
			ServiceCollection serviceBuilder = new ServiceCollection();
			ConfigureServices(serviceBuilder, configuration);
			this.serviceLocator = serviceBuilder.BuildServiceProvider();

			this.SetupDb();
		}

		private IConfiguration GetConfiguration() => new ConfigurationBuilder()
			.AddJsonFile("appsettings.json", optional: true)
			.AddJsonFile("appsettings.xunit.json", optional: true)
			.AddUserSecrets<DatabaseFixture>(optional: true)
			.AddEnvironmentVariables()
			.Build();

		private void ConfigureServices(IServiceCollection service, IConfiguration configuration)
		{
			service.AddSingleton<IConfiguration>(configuration);

			string connectionString = configuration.GetConnectionString("TodoConnectionString");

			DbContextOptions<TodoContext> options = new DbContextOptionsBuilder<TodoContext>()
				.UseSqlServer(connectionString)
				.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning))
				.Options;

			service.AddSingleton<DbContextOptions<TodoContext>>(options);

			// Transients so we get a new one each time:
			service.AddTransient<ITodoRepository, TodoRepository>();
			service.AddTransient<ITodoContext, TodoContext>();
			service.AddTransient<TodoRepository>(); // so tests can get it
		}

		public T GetService<T>() => this.serviceLocator.GetRequiredService<T>();

		private void SetupDb()
		{

			var options = this.GetService<DbContextOptions<TodoContext>>();

			using (var db = new TodoContext(options)) {
				// use ensure created or migrate but not both
				db.Database.EnsureCreated();
				//db.Database.Migrate();
			}

			using (var db = new TodoContext(options)) {
				// TODO: seed db
			}

		}

		// tear down db:
		public void Dispose()
		{
			var options = this.GetService<DbContextOptions<TodoContext>>();
			using (var db = new TodoContext(options)) {
				// TODO: truncate and reseed the database
				// or
				// TODO: delete database
			}
		}

	}
}

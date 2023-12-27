using Application.UseCases.CreateTask.Installers;
using Application.UseCases.DeleteTask.Installers;
using Application.UseCases.GetTask.Installers;
using Application.UseCases.UpdateTask.Installers;
using Infrastructure.SqlServer.Installers;
using Infrastructure.SqlServer.Repositories.TaskAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace WebApi.Installers
{
	public static class TaskInstaller
	{
		public static IServiceCollection AddTask(this IServiceCollection services, IConfiguration configuration)
		{
			Action<DbContextOptionsBuilder> options = AddOptions(configuration, "SqlServer");

			return services
				.AddDbContext<TaskDbContext>(options)
				.AddTaskRepository()
				.InstallCreateTaskUseCase()
				.InstallGetTaskUseCase()
				.InstallUpdateTaskUseCase()
				.InstallDeleteTaskUseCase();
		}

		private static Action<DbContextOptionsBuilder> AddOptions(IConfiguration configuration, string provider)
		{
			return options => _ = provider switch
			{
				"SqlServer" => options.UseSqlServer(configuration.GetConnectionString(provider), sqlServerOptionsAction: sqlOptions =>
				{
					sqlOptions.MigrationsAssembly("Infrastructure.SqlServer");
					sqlOptions.EnableRetryOnFailure(maxRetryCount: 1, maxRetryDelay: TimeSpan.FromSeconds(20), errorNumbersToAdd: null);
				}).ConfigureWarnings(cw => cw.Log((RelationalEventId.CommandExecuting, LogLevel.Error))),

				_ => throw new Exception($"Unsupported provider: {provider}")
			};
		}
	}
}

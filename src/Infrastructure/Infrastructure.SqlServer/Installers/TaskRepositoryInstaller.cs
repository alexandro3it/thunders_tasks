using Domain.TaskAggregate;
using Infrastructure.SqlServer.Repositories.TaskAggregate;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.SqlServer.Installers
{
	public static class TaskRepositoryInstaller
	{
		public static IServiceCollection AddTaskRepository(this IServiceCollection services) => 
			services.AddScoped<ITaskRepository, TaskRepository>();
	}
}

using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.CreateTask.Installers
{
	public static class CreateTaskUseCaseInstaller
	{
		public static IServiceCollection InstallCreateTaskUseCase(this IServiceCollection services)
		{
			services
				.AddScoped<ICreateTaskUseCase, CreateTaskUseCase>();

			return services;
		}
	}
}

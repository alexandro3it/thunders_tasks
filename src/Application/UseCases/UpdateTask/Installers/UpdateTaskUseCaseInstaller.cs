using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.UpdateTask.Installers
{
	public static class UpdateTaskUseCaseInstaller
	{
		public static IServiceCollection InstallUpdateTaskUseCase(this IServiceCollection services)
		{
			services
				.AddScoped<IUpdateTaskUseCase, UpdateTaskUseCase>();

			return services;
		}
	}
}

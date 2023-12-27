using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.DeleteTask.Installers
{
	public static class DeleteTaskUseCaseInstaller
	{
		public static IServiceCollection InstallDeleteTaskUseCase(this IServiceCollection services)
		{
			services
				.AddScoped<IDeleteTaskUseCase, DeleteTaskUseCase>();

			return services;
		}
	}
}

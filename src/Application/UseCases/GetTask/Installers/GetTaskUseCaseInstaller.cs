using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.GetTask.Installers
{
	public static class GetTaskUseCaseInstaller
	{
		public static IServiceCollection InstallGetTaskUseCase(this IServiceCollection services)
		{
			services
				.AddScoped<IGetTaskUseCase, GetTaskUseCase>();

			return services;
		}
	}
}

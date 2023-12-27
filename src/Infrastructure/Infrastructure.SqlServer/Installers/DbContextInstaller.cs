using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.SqlServer.Installers
{
	public static class DbContextInstaller
	{
		public static IServiceCollection AddDbContext<TContext, TFactory>(this IServiceCollection services, IConfiguration configuration)
			where TContext : DbContext
			where TFactory : IDbContextFactory<TContext>
		{
			return services;
		}
	}
}

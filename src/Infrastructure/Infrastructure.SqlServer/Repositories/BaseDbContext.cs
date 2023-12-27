using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServer.Repositories
{
	public abstract class BaseDbContext : DbContext
	{
		public BaseDbContext(DbContextOptions options)
						: base(options)
		{
		}

		protected abstract Type TypeContext { get; }
		protected abstract string DefaultSchema { get; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.HasDefaultSchema(DefaultSchema);
			modelBuilder.ApplyConfigurationsFromAssembly(TypeContext.Assembly);
		}
	}
}

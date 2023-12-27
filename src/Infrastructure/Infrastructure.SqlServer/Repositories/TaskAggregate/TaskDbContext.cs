using Microsoft.EntityFrameworkCore;

using Task = Domain.TaskAggregate.Task;

namespace Infrastructure.SqlServer.Repositories.TaskAggregate
{
	public class TaskDbContext : DbContext
	{
		public TaskDbContext() 
		{
		}

		public TaskDbContext(DbContextOptions options) 
			: base(options)
		{
		}

		public DbSet<Task> Tasks { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			optionsBuilder.UseSqlServer();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Task>().ToTable("Tasks");
			modelBuilder.Entity<Task>().HasIndex(t => new { t.TaskId }).IsUnique();
			modelBuilder.Entity<Task>().HasKey(model => model.Id);
			modelBuilder.Entity<Task>().Property(model => model.Date);
			modelBuilder.Entity<Task>().Property(model => model.Status);
			modelBuilder.Entity<Task>().Property(model => model.Description);
		}
	}
}

using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServer.Repositories
{
	public abstract class Repository<TEntity, TContext> : IRepository<TEntity>
			where TEntity : class, IEntity, IAggreateRoot
			where TContext : DbContext
	{
		protected Repository(TContext context)
		{
			_context = context;
		}

		protected readonly TContext _context;

		public async Task<int> CreateAsync(TEntity entity, CancellationToken cancellationToken)
		{
			await _context.AddAsync(entity, cancellationToken);
			await _context.SaveChangesAsync();
			return entity.Id;
		}

		public abstract Task<TEntity> GetAsync(string id);

		public async Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
		{
			_context.Update(entity);
			await _context.SaveChangesAsync();
			return entity.Id;
		}

		public async Task<bool> DeleteAsync(TEntity entity)
		{
			_context.Remove(entity);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}

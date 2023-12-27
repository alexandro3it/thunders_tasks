namespace Domain
{
	public interface IRepository<T>
		where T : IAggreateRoot
	{
		Task<int> CreateAsync(T entity, CancellationToken cancellationToken);		
		Task<T> GetAsync(string taskId);		
		Task<int> UpdateAsync(T entity, CancellationToken cancellationToken);
		Task<bool> DeleteAsync(T entity);
	}
}
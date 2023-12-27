using Domain.TaskAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServer.Repositories.TaskAggregate
{
	public sealed class TaskRepository : Repository<ITask, TaskDbContext>, ITaskRepository
	{
		public TaskRepository(TaskDbContext context) 
			: base(context)
		{
		}

		public async override Task<ITask> GetAsync(string id)
		{
			return await _context.Tasks.FirstOrDefaultAsync(model => model.TaskId == id);
		}
	}
}

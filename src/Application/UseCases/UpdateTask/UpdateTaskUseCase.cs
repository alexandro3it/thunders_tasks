using Application.UseCases.DeleteTask.Validators;
using Application.UseCases.UpdateTask.Dtos;
using Domain.TaskAggregate;

namespace Application.UseCases.UpdateTask
{
	public sealed class UpdateTaskUseCase : IUpdateTaskUseCase
	{
			private readonly ITaskRepository _dbContext;

		public UpdateTaskUseCase(ITaskRepository dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<UpdateTaskOutput> ExecuteAsync(string id, UpdateTaskInput input, CancellationToken cancellationToken)
		{
			UpdateTaskInputValidator validator = new();
			var result = validator.Validate(input);
			if (!result.IsValid)
			{
				return default!;
			}

			var task = await _dbContext.GetAsync(id) ?? throw new Exception("NotFound");
			task.Update(input.Description);
			await _dbContext.UpdateAsync(task, cancellationToken);

			UpdateTaskOutput output = new()
			{
				TaskId = task.TaskId,
				Date = task.Date,
				Status = task.Status,
				Description = task.Description
			};

			return output;
		}
	}
}

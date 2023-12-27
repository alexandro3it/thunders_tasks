using Application.UseCases.CreateTask.Dtos;
using Application.UseCases.CreateTask.Validators;
using Domain.TaskAggregate;

using Task = Domain.TaskAggregate.Task;

namespace Application.UseCases.CreateTask
{
	public sealed class CreateTaskUseCase : ICreateTaskUseCase
	{
		private readonly ITaskRepository _dbContext;

		public CreateTaskUseCase(ITaskRepository dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<CreateTaskOutput> ExecuteAsync(CreateTaskInput input, CancellationToken cancellationToken)
		{
			CreateTaskInputValidator validator = new();
			var result = validator.Validate(input);
			if (!result.IsValid)
			{
				return default!;
			}

			var task = Task.Add(input.Description);
			await _dbContext.CreateAsync(task, cancellationToken);

			CreateTaskOutput output = new()
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

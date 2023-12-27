using Application.UseCases.GetTask.Dtos;
using Application.UseCases.GetTask.Validators;
using Domain.TaskAggregate;

namespace Application.UseCases.GetTask
{
	public sealed class GetTaskUseCase : IGetTaskUseCase
	{
		private readonly ITaskRepository _dbContext;

		public GetTaskUseCase(ITaskRepository dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<GetTaskOutput> ExecuteAsync(GetTaskInput input, CancellationToken cancellationToken)
		{
			GetTaskInputValidator validator = new();
			var result = validator.Validate(input);
			if (!result.IsValid)
			{
				return default!;
			}

			var task = await _dbContext.GetAsync(input.TaskId);
			if (task is null)
			{
				return default!;
			}

			GetTaskOutput output = new()
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

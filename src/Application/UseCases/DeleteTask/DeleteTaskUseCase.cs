using Application.UseCases.DeleteTask.Dtos;
using Application.UseCases.DeleteTask.Validators;
using Domain.TaskAggregate;

namespace Application.UseCases.DeleteTask
{
	public sealed class DeleteTaskUseCase : IDeleteTaskUseCase
	{
		private readonly ITaskRepository _dbContext;

		public DeleteTaskUseCase(ITaskRepository dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<DeleteTaskOutput> ExecuteAsync(DeleteTaskInput input, CancellationToken cancellationToken)
		{
			DeleteTaskInputValidator validator = new();
			var result = validator.Validate(input);
			if (!result.IsValid)
			{
				return default!;
			}

			var task = await _dbContext.GetAsync(input.TaskId) ?? throw new Exception("NotFound");
			await _dbContext.DeleteAsync(task);

			DeleteTaskOutput output = new();
			return output;
		}
	}
}

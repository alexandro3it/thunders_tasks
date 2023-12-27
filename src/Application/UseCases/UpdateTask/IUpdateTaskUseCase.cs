using Application.UseCases.UpdateTask.Dtos;

namespace Application.UseCases.UpdateTask
{
	public interface IUpdateTaskUseCase
	{
		Task<UpdateTaskOutput> ExecuteAsync(string id, UpdateTaskInput input, CancellationToken cancellationToken);
	}
}

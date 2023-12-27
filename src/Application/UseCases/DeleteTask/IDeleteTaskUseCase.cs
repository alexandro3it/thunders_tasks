using Application.UseCases.DeleteTask.Dtos;

namespace Application.UseCases.DeleteTask
{
	public interface IDeleteTaskUseCase
	{
		Task<DeleteTaskOutput> ExecuteAsync(DeleteTaskInput input, CancellationToken cancellationToken);
	}
}

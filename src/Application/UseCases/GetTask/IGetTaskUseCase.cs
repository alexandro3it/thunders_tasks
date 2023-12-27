using Application.UseCases.GetTask.Dtos;

namespace Application.UseCases.GetTask
{
	public interface IGetTaskUseCase
	{
		Task<GetTaskOutput> ExecuteAsync(GetTaskInput input, CancellationToken cancellationToken);
	}
}

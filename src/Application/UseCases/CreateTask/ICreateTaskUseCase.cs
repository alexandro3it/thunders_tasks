using Application.UseCases.CreateTask.Dtos;

namespace Application.UseCases.CreateTask
{
	public interface ICreateTaskUseCase
	{
		Task<CreateTaskOutput> ExecuteAsync(CreateTaskInput input, CancellationToken cancellationToken);
	}
}

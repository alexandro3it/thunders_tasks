using Application.UseCases.DeleteTask;
using Application.UseCases.DeleteTask.Dtos;
using FluentAssertions;
using Moq;

using ITask = Domain.TaskAggregate.ITask;
using ITaskRepository = Domain.TaskAggregate.ITaskRepository;

namespace UnitTests.Application
{
	public class DeleteTaskUseCaseTests
	{
		private IDeleteTaskUseCase _useCase;
		private Mock<ITaskRepository> _repository;
		
		public DeleteTaskUseCaseTests()
		{
			_useCase = new DeleteTaskUseCase((_repository = new Mock<ITaskRepository>()).Object);
		}

		[Fact]
		public async Task Given_DeleteTask_ResultValidResponseTest()
		{
			DeleteTaskInput input = new()
			{
				TaskId = "1"
			};

			_repository
				.Setup(setup => setup.GetAsync(It.IsAny<string>()))
				.Returns(Task.FromResult(Domain.TaskAggregate.Task.Add("-")));
			_repository
				.Setup(setup => setup.DeleteAsync(It.IsAny<ITask>()))
				.Returns(Task.FromResult(true));

			var output = await _useCase.ExecuteAsync(input, CancellationToken.None);

			output.Deleted.Should().BeTrue();
		}
	}
}

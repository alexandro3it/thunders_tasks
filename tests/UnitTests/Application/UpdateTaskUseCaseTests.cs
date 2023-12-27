using Application.UseCases.UpdateTask;
using Application.UseCases.UpdateTask.Dtos;
using Moq;
using FluentAssertions;

using ITask = Domain.TaskAggregate.ITask;
using ITaskRepository = Domain.TaskAggregate.ITaskRepository;


namespace UnitTests.Application
{
	public class UpdateTaskUseCaseTests
	{
		private IUpdateTaskUseCase _useCase;
		private Mock<ITaskRepository> _repository;
		
		public UpdateTaskUseCaseTests()
		{
			_useCase = new UpdateTaskUseCase((_repository = new Mock<ITaskRepository>()).Object);
		}

		[Fact]
		public async Task Given_UpdateNewTask_ResultValidResponseTest()
		{
			UpdateTaskInput input = new()
			{
				Description = "Description"
			};

			_repository
				.Setup(setup => setup.GetAsync(It.IsAny<string>()))
				.Returns(Task.FromResult(Domain.TaskAggregate.Task.Add(input.Description)));
			_repository
				.Setup(setup => setup.UpdateAsync(It.IsAny<ITask>(), It.IsAny<CancellationToken>()))
				.Returns(Task.FromResult(1));

			var output = await _useCase.ExecuteAsync("1", input, CancellationToken.None);

			output.TaskId.Should().NotBeEmpty();
			output.Description.Should().NotBeEmpty();
			output.Description.Should().Be(input.Description);
		}
	}
}

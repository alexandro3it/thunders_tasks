using Application.UseCases.CreateTask;
using Application.UseCases.CreateTask.Dtos;
using Moq;
using FluentAssertions;

using ITask = Domain.TaskAggregate.ITask;
using ITaskRepository = Domain.TaskAggregate.ITaskRepository;


namespace UnitTests.Application
{
	public class CreateTaskUseCaseTests
	{
		private ICreateTaskUseCase _useCase;
		private Mock<ITaskRepository> _repository;
		
		public CreateTaskUseCaseTests()
		{
			_useCase = new CreateTaskUseCase((_repository = new Mock<ITaskRepository>()).Object);
		}

		[Fact]
		public async Task Given_CreateNewTask_ResultValidResponseTest()
		{
			CreateTaskInput input = new()
			{
				Description = "Description"
			};

			_repository
				.Setup(setup => setup.CreateAsync(It.IsAny<ITask>(), It.IsAny<CancellationToken>()))
				.Returns(Task.FromResult(1));

			var output = await _useCase.ExecuteAsync(input, CancellationToken.None);

			output.TaskId.Should().NotBeEmpty();
			output.Description.Should().NotBeEmpty();
			output.Description.Should().Be(input.Description);
		}
	}
}

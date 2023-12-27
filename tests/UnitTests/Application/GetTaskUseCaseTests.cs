using Application.UseCases.GetTask;
using Application.UseCases.GetTask.Dtos;
using FluentAssertions;
using Moq;

using ITaskRepository = Domain.TaskAggregate.ITaskRepository;


namespace UnitTests.Application
{
	public class GetTaskUseCaseTests
	{
		private IGetTaskUseCase _useCase;
		private Mock<ITaskRepository> _repository;
		
		public GetTaskUseCaseTests()
		{
			_useCase = new GetTaskUseCase((_repository = new Mock<ITaskRepository>()).Object);
		}

		[Fact]
		public async Task Given_GetTask_ResultValidResponseTest()
		{
			GetTaskInput input = new()
			{
				TaskId = "1"
			};

			_repository
				.Setup(setup => setup.GetAsync(It.IsAny<string>()))
				.Returns(Task.FromResult(Domain.TaskAggregate.Task.Add("-")));
			
			var output = await _useCase.ExecuteAsync(input, CancellationToken.None);

			output.TaskId.Should().NotBeEmpty();
			output.Description.Should().NotBeEmpty();
		}
	}
}

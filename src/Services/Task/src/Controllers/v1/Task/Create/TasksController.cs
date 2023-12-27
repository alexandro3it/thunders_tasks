using Application.UseCases.CreateTask;
using Application.UseCases.CreateTask.Dtos;
using Microsoft.AspNetCore.Mvc;
using Serilog.Context;
using SerilogTimings;
using Swashbuckle.AspNetCore.Annotations;
using WebApi.Result;

namespace WebApi.Controllers.v1.Task.Create
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{v:apiVersion}")]
	[Produces("application/json")]
	[SwaggerTag("Tasks")]
	public class TasksController : ControllerBase
	{
		private readonly ICreateTaskUseCase _useCase;

		public TasksController(ICreateTaskUseCase useCase) => _useCase = useCase;

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Post(
			[FromHeader] Guid correlationId,
			[FromBody] CreateTaskInput input,
			CancellationToken token)
		{
			using (LogContext.PushProperty(nameof(correlationId), correlationId))
			using (Operation.Time("[{Controller}] - Executing", nameof(TasksController)))
				try
				{
					CreateTaskOutput output;
					if ((output = await _useCase.ExecuteAsync(input, token)) is null)
					{
						return BadRequest();
					}

					return Ok(output);
				}
				catch (Exception ex)
				{
					return new InternalServerErrorObjectResult(ex.Message);
				}
		}
	}
}

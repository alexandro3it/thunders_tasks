using Application.UseCases.GetTask;
using Application.UseCases.GetTask.Dtos;
using Microsoft.AspNetCore.Mvc;
using Serilog.Context;
using SerilogTimings;
using Swashbuckle.AspNetCore.Annotations;
using WebApi.Result;

namespace WebApi.Controllers.v1.Task.Get
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{v:apiVersion}")]
	[Produces("application/json")]
	[SwaggerTag("Tasks")]
	public class TasksController : ControllerBase
	{
		private readonly IGetTaskUseCase _useCase;

		public TasksController(IGetTaskUseCase useCase) => _useCase = useCase;

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Get(
			[FromHeader] Guid correlationId,
			[FromRoute] string id,
			CancellationToken token)
		{
			using (LogContext.PushProperty(nameof(correlationId), correlationId))
			using (Operation.Time("[{Controller}] - Executing", nameof(TasksController)))
				try
				{
					if (string.IsNullOrEmpty(id))
					{
						return BadRequest();
					}

					GetTaskInput input = new() { TaskId = id };
					GetTaskOutput output;
					if ((output = await _useCase.ExecuteAsync(input, token)) is null)
					{
						return NotFound();
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

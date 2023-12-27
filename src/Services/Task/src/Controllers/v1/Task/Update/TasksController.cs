using Application.UseCases.UpdateTask;
using Application.UseCases.UpdateTask.Dtos;
using Microsoft.AspNetCore.Mvc;
using Serilog.Context;
using SerilogTimings;
using Swashbuckle.AspNetCore.Annotations;
using WebApi.Result;

namespace WebApi.Controllers.v1.Task.Update
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{v:apiVersion}")]
	[Produces("application/json")]
	[SwaggerTag("Tasks")]
	public class TasksController : ControllerBase
	{
		private readonly IUpdateTaskUseCase _useCase;

		public TasksController(IUpdateTaskUseCase useCase) => _useCase = useCase;

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Put(
			[FromHeader] Guid correlationId,
			[FromRoute] string id,
			[FromBody] UpdateTaskInput input,
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

					UpdateTaskOutput output;
					if ((output = await _useCase.ExecuteAsync(id, input, token)) is null)
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

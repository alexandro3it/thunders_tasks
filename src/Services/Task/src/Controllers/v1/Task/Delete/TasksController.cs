using Application.UseCases.DeleteTask;
using Application.UseCases.DeleteTask.Dtos;
using Microsoft.AspNetCore.Mvc;
using Serilog.Context;
using SerilogTimings;
using Swashbuckle.AspNetCore.Annotations;
using WebApi.Result;

namespace WebApi.Controllers.v1.Task.Delete
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{v:apiVersion}")]
	[Produces("application/json")]
	[SwaggerTag("Tasks")]
	public class TasksController : ControllerBase
	{
		private readonly IDeleteTaskUseCase _useCase;

		public TasksController(IDeleteTaskUseCase useCase) => _useCase = useCase;		

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Delete(
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

					DeleteTaskInput input = new() { TaskId = id };
					if ((await _useCase.ExecuteAsync(input, token)) is null)
					{
						return NotFound();
					}

					return NoContent();
				}
				catch (Exception ex)
				{
					return new InternalServerErrorObjectResult(ex.Message);
				}
		}
	}
}

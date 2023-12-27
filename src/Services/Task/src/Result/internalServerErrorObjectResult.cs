using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WebApi.Result
{
	[DefaultStatusCode(StatusCodes.Status500InternalServerError)]
	public sealed class InternalServerErrorObjectResult : ObjectResult
	{
		public InternalServerErrorObjectResult([ActionResultObjectValue] object error)
			: base(error)
		{
			StatusCode = StatusCodes.Status500InternalServerError;
		}
	}
}
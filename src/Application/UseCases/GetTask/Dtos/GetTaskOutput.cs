using Domain.Enums;

namespace Application.UseCases.GetTask.Dtos
{
	public record GetTaskOutput
	{
		public string TaskId { get; set; }
		public DateTime Date { get; set; }
		public Status Status { get; set; }
		public string Description { get; set; }
	}
}

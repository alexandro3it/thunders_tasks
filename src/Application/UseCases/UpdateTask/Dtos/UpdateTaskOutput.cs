using Domain.Enums;

namespace Application.UseCases.UpdateTask.Dtos
{
	public record UpdateTaskOutput
	{
		public string TaskId { get; set; }
		public DateTime Date { get; set; }
		public Status Status { get; set; }
		public string Description { get; set; }
	}
}

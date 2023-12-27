using Domain.Enums;

namespace Application.UseCases.CreateTask.Dtos
{
	public record CreateTaskOutput
	{
		public string TaskId { get; set; }
		public DateTime Date { get; set; }
		public Status Status { get; set; }
		public string Description { get; set; }
	}
}

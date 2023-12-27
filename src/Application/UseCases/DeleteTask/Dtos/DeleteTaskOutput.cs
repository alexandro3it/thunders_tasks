namespace Application.UseCases.DeleteTask.Dtos
{
	public record DeleteTaskOutput
	{
		public bool Deleted { get; set; } = true;
	}
}

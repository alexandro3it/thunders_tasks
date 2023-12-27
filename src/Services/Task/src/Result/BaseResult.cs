namespace WebApi.Result
{
	public class BaseResult
	{
		public bool IsValid => !Erros.Any();
		public List<Error> Erros { get; set; } = new List<Error>();
	}
}

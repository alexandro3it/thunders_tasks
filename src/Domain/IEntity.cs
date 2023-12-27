namespace Domain
{
	public interface IEntity
	{
		int Id { get; }
		DateTimeOffset CreateAt { get; }
	}
}
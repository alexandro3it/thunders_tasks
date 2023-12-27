using Domain.Enums;

namespace Domain.TaskAggregate
{
	public interface ITask : IEntity, IAggreateRoot
	{
		string TaskId { get; }
		DateTime Date { get; }
		Status Status { get; }
		string Description { get; }

		ITask Update(string description);
	}
}

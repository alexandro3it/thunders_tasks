using Domain.Enums;

namespace Domain.TaskAggregate
{
	public sealed class Task : Entity, ITask
	{
		private Task()
			: this(Guid.NewGuid().ToString())
		{
		}

		private Task(string taskId)
		{
			TaskId = taskId;
		}

		public string TaskId
		{
			get;
			private set;
		}

		public DateTime Date
		{
			get;
			private set;
		}

		public Status Status
		{
			get;
			private set;
		}

		public string Description
		{
			get;
			private set;
		}

		public static ITask Add(string description)
		{
			return new Task()
			{
				Date = DateTime.Now,
				Status = Status.Active,
				Description = description
			};
		}

		public ITask Update(string description)
		{
			Description = description;
			return this;
		}
	}
}

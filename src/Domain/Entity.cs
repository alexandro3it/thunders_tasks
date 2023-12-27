namespace Domain
{
	public abstract class Entity : IEntity
	{
		public int Id
		{
			get;
			protected set;
		}

		public DateTimeOffset CreateAt
		{
			get;
			protected set;
		} = DateTimeOffset.Now;
	}
}
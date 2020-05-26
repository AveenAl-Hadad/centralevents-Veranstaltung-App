namespace CentralEvents.DataAccess.Contracts.Entities
{
	using System;

	public class EntityBase
	{
		public Guid Id { get; protected set; }
	}
}
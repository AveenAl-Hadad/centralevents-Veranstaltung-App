﻿namespace CentralEvents.DataAccess.Contracts.Exeptions
{
	using System;

	public class EntityNotFoundException : Exception
	{
		public EntityNotFoundException(Type type, Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
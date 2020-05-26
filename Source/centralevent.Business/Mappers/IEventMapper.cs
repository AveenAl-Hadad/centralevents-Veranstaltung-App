﻿namespace CentralEvent.Business.Mappers
{
	using CentralEvent.Business.Contracts.Models;

	using CentralEvents.DataAccess.Contracts.Entities;

	public interface IEventMapper
	{
		EventModel EventEntityToModel(EventEntity eventEntity);
	}
}
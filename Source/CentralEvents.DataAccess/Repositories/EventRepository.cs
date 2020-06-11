namespace CentralEvents.DataAccess.Repositories
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using CentralEvents.DataAccess.Contracts.Context;
	using CentralEvents.DataAccess.Contracts.Entities;
	using CentralEvents.DataAccess.Contracts.Exeptions;
	using CentralEvents.DataAccess.Contracts.Repositories;

	using Microsoft.EntityFrameworkCore;

	public class EventRepository : IEventRepository
	{
		private readonly IDataContext dataContext;

		public EventRepository(IDataContext dataContext)
		{
			this.dataContext = dataContext;
		}

		//CRUD

		//CREATE
		public void AddEvent(EventEntity eventEntity)
		{
			this.dataContext.Add(eventEntity);
		}

		public void AddBooking(BookingEntity bookingEntity)
		{
			this.dataContext.Add(bookingEntity);
		}

		public void AddCustomer(CustomerEntity customerEntity)
		{
			this.dataContext.Add(customerEntity);
		}

		//READ
		public IEnumerable<EventEntity> GetEvents()
		{
			return this.dataContext.Query<EventEntity>().ToArray();
		}

		public EventEntity GetEvent(Guid id)
		{
			EventEntity eventEntity = this.dataContext.Query<EventEntity>().FirstOrDefault(e => e.Id == id);

			if (eventEntity == null)
			{
				throw new EntityNotFoundException(typeof(EventEntity), id);
			}

			return eventEntity;
		}

		public CustomerEntity GetCustomer(Guid guid)
		{
			CustomerEntity customerEntity = this.dataContext.Query<CustomerEntity>().FirstOrDefault(e => e.Id == guid);

			if (customerEntity == null)
			{
				throw new EntityNotFoundException(typeof(CustomerEntity), guid);
			}

			return customerEntity;
		}

		public CustomerEntity GetCustomerByUserName(string userName)
		{
			CustomerEntity customerEntity = this.dataContext.Query<CustomerEntity>()
							.FirstOrDefault(e => e.Benutzername == userName);

			if (customerEntity == null)
			{
				throw new EntityNotFoundException(typeof(CustomerEntity), userName);
			}

			return customerEntity;
		}


		public IEnumerable<CustomerEntity> GetCustomerS()
		{
			return this.dataContext.Query<CustomerEntity>().ToArray();
		}

		//UPDATE
		public void SaveChangedRepository()
		{
			this.dataContext.SaveChangedRepository();
		}

		// REMOVE
		public void RemoveEvent(EventEntity eventEntity)
		{
			this.dataContext.Remove(eventEntity);
		}
	}
}
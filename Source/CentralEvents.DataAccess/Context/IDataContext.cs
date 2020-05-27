namespace CentralEvents.DataAccess.Context
{
	using System.Linq;

	using CentralEvents.DataAccess.Contracts.Entities;

	public interface IDataContext
	{
		IQueryable<TEntity> Query<TEntity>() where TEntity : EntityBase;

		void Add<TEntity>(TEntity entity);

		void SaveChanges();

		void Remove<TEntity>(TEntity entity);
	}
}
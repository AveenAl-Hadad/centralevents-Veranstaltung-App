namespace CentralEvents.DataAccess.Contracts.Context
{
	using System.Linq;

	using CentralEvents.DataAccess.Contracts.Entities;

	public interface IDataContext
	{
		void Add<TEntity>(TEntity entity) where TEntity : EntityBase;

		IQueryable<TEntity> Query<TEntity>() where TEntity : EntityBase;

		void SaveChangedRepository();

		void Remove<TEntity>(TEntity entity) where TEntity : EntityBase;
	}
}
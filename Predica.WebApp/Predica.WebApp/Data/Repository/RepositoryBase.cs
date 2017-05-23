using System.Linq;
using Microsoft.EntityFrameworkCore;
using Predica.WebApp.Data.Entity.Base;

namespace Predica.WebApp.Data.Repository
{
	public class RepositoryBase<TDbContext, TEntity, TPrimaryKey> where TDbContext : DbContext
													where TEntity : BaseEntity<TPrimaryKey>
	{
		protected readonly TDbContext Context;

		protected RepositoryBase(TDbContext context)
		{
			Context = context;
		}

		protected virtual IQueryable<TEntity> GetAll()
		{
			return Context.Set<TEntity>();
		}

		protected TEntity GetByEntityId(TPrimaryKey id)
		{
			return GetAll().FirstOrDefault(e => e.Id.Equals(id));
		}

		protected TEntity Insert(TEntity entity)
		{
			return Context.Set<TEntity>().Add(entity).Entity;
		}

		protected TEntity Delete(TEntity entity)
		{
			return Context.Set<TEntity>().Remove(entity).Entity;
		}

		protected TEntity Update(TEntity entity)
		{
			AttachIfIsNot(entity);
			return Context.Set<TEntity>().Update(entity).Entity;
		}

		protected void SaveChanges()
		{
			Context.SaveChanges();
		}

		private void AttachIfIsNot(TEntity entity)
		{
			var entry = Context.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);
			if (entry == null)
			{
				Context.Attach(entity);
			}
		}
	}
}

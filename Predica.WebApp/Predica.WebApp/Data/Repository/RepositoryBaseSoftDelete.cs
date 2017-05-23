using System.Linq;
using Microsoft.EntityFrameworkCore;
using Predica.WebApp.Data.Entity.Base;

namespace Predica.WebApp.Data.Repository
{
    public class RepositoryBaseSoftDelete<TDbContext, TEntity, TPrimaryKey> : RepositoryBase<TDbContext, TEntity, TPrimaryKey> where TDbContext : DbContext
	    where TEntity : BaseEntitySoftDelete<TPrimaryKey>
	{
		protected RepositoryBaseSoftDelete(TDbContext context) : base(context)
		{
		}

		protected override IQueryable<TEntity> GetAll()
		{
			return Context.Set<TEntity>().Where(e => !e.IsDeleted);
		}
	}
}

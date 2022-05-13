using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace VisitorSystem.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Base class for custom repositories of the application.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
    //public abstract class VisitorSystemRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<VisitorSystemDbContext, TEntity, TPrimaryKey>
    //    where TEntity : class, IEntity<TPrimaryKey>
    //{
    //    protected VisitorSystemRepositoryBase(IDbContextProvider<VisitorSystemDbContext> dbContextProvider)
    //        : base(dbContextProvider)
    //    {
    //    }

    //    // Add your common methods for all repositories
    //}

    public abstract class VisitorSystemRepositoryBase<TDbContext, TEntity, TPrimaryKey> : EfCoreRepositoryBase<TDbContext, TEntity, TPrimaryKey>
   where TEntity : class, IEntity<TPrimaryKey>
   where TDbContext : AbpDbContext
    {
        protected VisitorSystemRepositoryBase(IDbContextProvider<TDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
    /// <summary>
    /// Base class for custom repositories of the application.
    /// This is a shortcut of <see cref="VisitorSystemRepositoryBase{TEntity,TPrimaryKey}"/> for <see cref="int"/> primary key.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class VisitorSystemRepositoryBase<TDbContext, TEntity> : VisitorSystemRepositoryBase<TDbContext, TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity<int>
         where TDbContext : AbpDbContext

    {
        protected VisitorSystemRepositoryBase(IDbContextProvider<TDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        // Do not add any method here, add to the class above (since this inherits it)!!!
    }
}

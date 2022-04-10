using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Textor.GRA.Domain.Entities.Interfaces;
using Textor.GRA.Domain.Framework.Response;

namespace Textor.GRA.Domain.Repositories.Base
{
    public interface IRepository
    {

    }
    public interface IWriteRepository
    {

    }
    public interface IReadRepository
    {

    }

    public interface IRepository<TEntity> where TEntity : IEntity
    {

    }

    public interface IWriteRepository<TEntity> : IWriteRepository, IRepository<TEntity> where TEntity : IEntity
    {
        Response Add(TEntity entity);
        Response AddRange(IList<TEntity> entities);
        Response SaveChanges();
    }

    public interface IReadRepository<TEntity> : IReadRepository, IRepository<TEntity> where TEntity : IEntity
    {
        IQueryable<TEntity> Get();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
    }
}

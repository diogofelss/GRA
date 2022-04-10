using System;
using System.Collections.Generic;
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
    }

    public interface IReadRepository<TEntity> : IReadRepository, IRepository<TEntity> where TEntity : IEntity
    {
        Tuple<Response, TEntity> Get();
        Tuple<Response, bool> Any();
        TEntity First();
    }
}

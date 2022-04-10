using System.Collections.Generic;
using Textor.GRA.Domain.Entities.Interfaces;
using Textor.GRA.Domain.Framework.Response;
using Textor.GRA.Domain.Repositories.Base;

namespace Textor.GRA.Domain.Services.Interfaces.Base
{
    public interface IDomainService
    {
    }

    public interface IDomainService<TEntity, TWriteRepository> : IDomainService
        where TEntity : IEntity
        where TWriteRepository : IWriteRepository<TEntity>
    {
        Response Add(TEntity entity);
        Response AddRange(IList<TEntity> entities);
    }
}

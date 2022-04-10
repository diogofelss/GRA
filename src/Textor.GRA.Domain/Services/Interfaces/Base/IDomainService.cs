using System.Collections.Generic;
using System.Threading.Tasks;
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
        Task<Response> Add(TEntity entity);
        Task<Response> AddRange(IList<TEntity> entities);
    }
}

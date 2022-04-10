using System.Collections.Generic;
using System.Threading.Tasks;
using Textor.GRA.Domain.Entities.Base;
using Textor.GRA.Domain.Framework.Response;
using Textor.GRA.Domain.Framework.Response.Enums;
using Textor.GRA.Domain.Repositories.Base;
using Textor.GRA.Domain.Services.Interfaces.Base;

namespace Textor.GRA.Domain.Services.Base
{
    public abstract class DomainService<TEntity, TWriteRepository> : IDomainService<TEntity, TWriteRepository>
        where TEntity : Entity
        where TWriteRepository : IWriteRepository<TEntity>
    {
        public readonly TWriteRepository Repository;

        public DomainService(TWriteRepository repository)
        {
            Repository = repository;
        }

        public virtual async Task<Response> Add(TEntity entity)
        {
            await Repository.Add(entity);

            return new Response
            {
                Message = "",
                Result = EResult.Success
            };
        }

        public virtual async Task<Response> AddRange(IList<TEntity> entities)
        {
            await Repository.AddRange(entities);

            return new Response
            {
                Message = "",
                Result = EResult.Success
            };
        }
    }
}

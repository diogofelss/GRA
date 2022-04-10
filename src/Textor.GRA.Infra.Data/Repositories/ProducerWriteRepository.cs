using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Textor.GRA.Domain.Entities;
using Textor.GRA.Domain.Framework.Response;
using Textor.GRA.Domain.Framework.Response.Enums;
using Textor.GRA.Domain.Repositories;
using Textor.GRA.Infra.Data.Context;
using Textor.GRA.Infra.Data.Repositories.Base;

namespace Textor.GRA.Infra.Data.Repositories
{
    public class ProducerWriteRepository : Repository<GeneralContext>, IProducerWriteRepository
    {
        public ProducerWriteRepository(GeneralContext context) : base(context)
        {

        }

        public async Task<Response> Add(Producer entity)
        {
            await Context .Producers.AddAsync(entity);

            return new Response
            {
                Message = "",
                Result = EResult.Success
            };
        }

        public async Task<Response> AddRange(IList<Producer> entities)
        {
            var array = entities.ToArray();

            await Context.Producers.AddRangeAsync(array);

            return new Response
            {
                Message = "",
                Result = EResult.Success
            };
        }

        public async Task<Response> SaveChanges()
        {
            await Context.SaveChangesAsync();

            return new Response
            {
                Message = "",
                Result = EResult.Success
            };
        }
    }
}

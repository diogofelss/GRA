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
    public class StudioWriteRepository : Repository<GeneralContext>, IStudioWriteRepository
    {
        public StudioWriteRepository(GeneralContext context) : base(context)
        {

        }

        public async Task<Response> Add(Studio entity)
        {
            await Context.Studios.AddAsync(entity);

            return new Response
            {
                Message = "",
                Result = EResult.Success
            };
        }

        public async Task<Response> AddRange(IList<Studio> entities)
        {
            var array = entities.ToArray();

            await Context.Studios.AddRangeAsync(array);

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

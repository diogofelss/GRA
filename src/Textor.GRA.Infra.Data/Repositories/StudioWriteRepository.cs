using System.Collections.Generic;
using System.Linq;
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

        public Response Add(Studio entity)
        {
            Context.Studios.Add(entity);

            return new Response
            {
                Message = "",
                Result = EResult.Success
            };
        }

        public Response AddRange(IList<Studio> entities)
        {
            var array = entities.ToArray();

            Context.Studios.AddRange(array);

            return new Response
            {
                Message = "",
                Result = EResult.Success
            };
        }

        public Response SaveChanges()
        {
            Context.SaveChanges();

            return new Response
            {
                Message = "",
                Result = EResult.Success
            };
        }
    }
}

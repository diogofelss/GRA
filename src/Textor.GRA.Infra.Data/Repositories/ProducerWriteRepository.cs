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
    public class ProducerWriteRepository : Repository<GeneralContext>, IProducerWriteRepository
    {
        public ProducerWriteRepository(GeneralContext context) : base(context)
        {

        }

        public Response Add(Producer entity)
        {
            Context.Producers.Add(entity);

            return new Response
            {
                Message = "",
                Result = EResult.Success
            };
        }

        public Response AddRange(IList<Producer> entities)
        {
            var array = entities.ToArray();

            Context.Producers.AddRange(array);

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

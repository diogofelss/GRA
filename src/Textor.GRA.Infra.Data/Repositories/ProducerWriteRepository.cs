using System;
using System.Collections.Generic;
using Textor.GRA.Domain.Entities;
using Textor.GRA.Domain.Framework.Response;
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
            throw new NotImplementedException();
        }

        public Response AddRange(IList<Producer> entities)
        {
            throw new NotImplementedException();
        }
    }
}

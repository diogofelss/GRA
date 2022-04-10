using System;
using Textor.GRA.Domain.Entities;
using Textor.GRA.Domain.Framework.Response;
using Textor.GRA.Domain.Repositories;
using Textor.GRA.Domain.Repositories.Base;
using Textor.GRA.Infra.Data.Context;
using Textor.GRA.Infra.Data.Repositories.Base;

namespace Textor.GRA.Infra.Data.Repositories
{
    public class ProducerReadRepository : Repository<GeneralContext>, IProducerReadRepository
    {
        public ProducerReadRepository(GeneralContext context) : base(context)
        {

        }

        public Producer First()
        {
            throw new NotImplementedException();
        }

        Tuple<Response, bool> IReadRepository<Producer>.Any()
        {
            throw new NotImplementedException();
        }

        Tuple<Response, Producer> IReadRepository<Producer>.Get()
        {
            throw new NotImplementedException();
        }
    }
}

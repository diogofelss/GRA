using System;
using Textor.GRA.Domain.Entities;
using Textor.GRA.Domain.Framework.Response;
using Textor.GRA.Domain.Repositories;
using Textor.GRA.Infra.Data.Context;
using Textor.GRA.Infra.Data.Repositories.Base;

namespace Textor.GRA.Infra.Data.Repositories
{
    public class StudioReadRepository : Repository<GeneralContext>, IStudioReadRepository
    {
        public StudioReadRepository(GeneralContext context) : base(context)
        {

        }

        public Tuple<Response, bool> Any()
        {
            throw new NotImplementedException();
        }

        public Studio First()
        {
            throw new NotImplementedException();
        }

        public Tuple<Response, Studio> Get()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using Textor.GRA.Domain.Entities;
using Textor.GRA.Domain.Framework.Response;
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
            throw new NotImplementedException();
        }

        public Response AddRange(IList<Studio> entities)
        {
            throw new NotImplementedException();
        }
    }
}

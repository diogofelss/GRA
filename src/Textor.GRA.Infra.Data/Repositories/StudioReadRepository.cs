using System;
using System.Linq;
using System.Linq.Expressions;
using Textor.GRA.Domain.Entities;
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

        public IQueryable<Studio> Get()
        {
            return Context.Studios;
        }

        public IQueryable<Studio> Get(Expression<Func<Studio, bool>> predicate)
        {
            return Context.Studios.Where(predicate);
        }

        public IQueryable<Studio> Sql(string query)
        {
            throw new NotImplementedException();
        }
    }
}

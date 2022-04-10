using Microsoft.EntityFrameworkCore;
using Textor.GRA.Domain.Repositories.Base;

namespace Textor.GRA.Infra.Data.Repositories.Base
{

    public interface IContextRepository<TContext> : IRepository where TContext : DbContext
    {

    }

    public class Repository<TContext> : IContextRepository<TContext> where TContext : DbContext
    {
        public readonly TContext Context;

        public Repository(TContext context)
        {
            Context = context;
        }
    }
}

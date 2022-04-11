using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using Textor.GRA.Domain.Entities;
using Textor.GRA.Domain.Repositories;
using Textor.GRA.Infra.Data.Context;
using Textor.GRA.Infra.Data.Repositories.Base;

namespace Textor.GRA.Infra.Data.Repositories
{
    public class MovieReadRepository : Repository<GeneralContext>, IMovieReadRepository
    {
        public MovieReadRepository(GeneralContext context) : base(context)
        {
        }

        public IQueryable<Movie> Get()
        {
            return Context.Movies;
        }

        public IQueryable<Movie> Get(Expression<Func<Movie, bool>> predicate)
        {
            return Context.Movies.Where(predicate);
        }

        public IQueryable<Movie> Sql(string query)
        {
            return Context.Movies.FromSqlRaw(query);
        }
    }
}

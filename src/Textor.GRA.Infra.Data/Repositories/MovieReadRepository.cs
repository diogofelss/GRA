using System;
using System.Collections.Generic;
using System.Linq;
using Textor.GRA.Domain.Entities;
using Textor.GRA.Domain.Framework.Response;
using Textor.GRA.Domain.Repositories;
using Textor.GRA.Domain.Repositories.Base;
using Textor.GRA.Infra.Data.Context;
using Textor.GRA.Infra.Data.Repositories.Base;

namespace Textor.GRA.Infra.Data.Repositories
{
    public class MovieReadRepository : Repository<GeneralContext>, IMovieReadRepository
    {
        public MovieReadRepository(GeneralContext context) : base(context)
        {

        }

        public Movie First()
        {
            return Context.Movies.AsQueryable().FirstOrDefault();
        }

        public IList<Movie> GetAll()
        {
            return Context.Movies.AsQueryable().ToList();
        }

        Tuple<Response, bool> IReadRepository<Movie>.Any()
        {
            throw new NotImplementedException();
        }

        Tuple<Response, Movie> IReadRepository<Movie>.Get()
        {
            throw new NotImplementedException();
        }
    }
}

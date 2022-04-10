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
    public class MovieWriteRepository : Repository<GeneralContext>, IMovieWriteRepository
    {
        public MovieWriteRepository(GeneralContext context) : base(context)
        {

        }

        public Response Add(Movie entity)
        {
            Context.Movies.Add(entity);

            return new Response
            {
                Message = "",
                Result = EResult.Success
            };
        }

        public Response AddProducer(MovieProducer producer)
        {
            Context.MovieProducers.Add(producer);

            return new Response
            {
                Message = "",
                Result = EResult.Success
            };
        }

        public Response AddRange(IList<Movie> entities)
        {
            var array = entities.ToArray();

            Context.Movies.AddRange(array);

            return new Response
            {
                Message = "",
                Result = EResult.Success
            };
        }

        public Response AddStudio(MovieStudio studio)
        {
            Context.MovieStudios.Add(studio);

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

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<Response> Add(Movie entity)
        {
            await Context.Movies.AddAsync(entity);

            return new Response
            {
                Message = "",
                Result = EResult.Success
            };
        }

        public async Task<Response> AddProducer(MovieProducer producer)
        {
            await Context.MovieProducers.AddAsync(producer);

            return new Response
            {
                Message = "",
                Result = EResult.Success
            };
        }

        public async Task<Response> AddRange(IList<Movie> entities)
        {
            var array = entities.ToArray();

            await Context.Movies.AddRangeAsync(array);

            return new Response
            {
                Message = "",
                Result = EResult.Success
            };
        }

        public async Task<Response> AddStudio(MovieStudio studio)
        {
            await Context.MovieStudios.AddAsync(studio);

            return new Response
            {
                Message = "",
                Result = EResult.Success
            };
        }

        public async Task<Response> SaveChanges()
        {
            await Context.SaveChangesAsync();

            return new Response
            {
                Message = "",
                Result = EResult.Success
            };
        }
    }
}

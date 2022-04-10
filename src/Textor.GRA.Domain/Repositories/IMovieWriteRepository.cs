using System.Threading.Tasks;
using Textor.GRA.Domain.Entities;
using Textor.GRA.Domain.Framework.Response;
using Textor.GRA.Domain.Repositories.Base;

namespace Textor.GRA.Domain.Repositories
{
    public interface IMovieWriteRepository : IWriteRepository<Movie>
    {
        Task<Response> AddStudio(MovieStudio studio);
        Task<Response> AddProducer(MovieProducer producer);
    }
}

using Textor.GRA.Domain.Entities;
using Textor.GRA.Domain.Framework.Response;
using Textor.GRA.Domain.Repositories.Base;

namespace Textor.GRA.Domain.Repositories
{
    public interface IMovieWriteRepository : IWriteRepository<Movie>
    {
        Response AddStudio(MovieStudio studio);
        Response AddProducer(MovieProducer producer);
    }
}

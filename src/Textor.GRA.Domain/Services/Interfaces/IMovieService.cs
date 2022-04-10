using Textor.GRA.Domain.Entities;
using Textor.GRA.Domain.Repositories;
using Textor.GRA.Domain.Services.Interfaces.Base;

namespace Textor.GRA.Domain.Services.Interfaces
{
    public interface IMovieService : IDomainService<Movie, IMovieWriteRepository>
    {
    }
}

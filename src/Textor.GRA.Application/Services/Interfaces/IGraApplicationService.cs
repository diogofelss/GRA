using System.Collections.Generic;
using Textor.GRA.Application.DTOs;
using Textor.GRA.Application.Services.Interfaces.Base;
using Textor.GRA.Domain.Repositories;
using Textor.GRA.Domain.Services.Interfaces;

namespace Textor.GRA.Application.Services.Interfaces
{
    public interface IGraApplicationService : IApplicationService<IMovieService, IMovieReadRepository>
    {
        IList<MovieResponseDTO> GetAll();
    }
}

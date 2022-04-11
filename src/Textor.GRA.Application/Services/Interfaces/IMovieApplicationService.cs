using System.Collections.Generic;
using System.Threading.Tasks;
using Textor.GRA.Application.DTOs;
using Textor.GRA.Application.Services.Interfaces.Base;
using Textor.GRA.Application.ViewModels;
using Textor.GRA.Domain.Framework.Response;

namespace Textor.GRA.Application.Services.Interfaces
{
    public interface IMovieApplicationService : IApplicationService
    {
        IList<MovieResponseViewModel> GetNominated(int year);
        IList<MovieResponseViewModel> GetWinners(int year);
        IList<MovieResponseViewModel> GetNominated();
        IList<MovieResponseViewModel> GetWinners();
    }
}

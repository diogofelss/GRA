using Textor.GRA.Application.Services.Interfaces.Base;
using Textor.GRA.Application.ViewModels;

namespace Textor.GRA.Application.Services.Interfaces
{
    public interface IProducerApplicationService : IApplicationService
    {
        ProducerWinnerTimeResponseViewModel GetInterval();
    }
}

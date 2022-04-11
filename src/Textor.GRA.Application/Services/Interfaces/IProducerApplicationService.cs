using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Textor.GRA.Application.Services.Interfaces.Base;
using Textor.GRA.Application.ViewModels;

namespace Textor.GRA.Application.Services.Interfaces
{
    public interface IProducerApplicationService : IApplicationService
    {
        ProducerWinnerTimeResponseViewModel GetInterval();
    }
}

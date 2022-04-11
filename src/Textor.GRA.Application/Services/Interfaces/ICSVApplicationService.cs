using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Textor.GRA.Application.DTOs;
using Textor.GRA.Application.Services.Interfaces.Base;
using Textor.GRA.Domain.Framework.Response;

namespace Textor.GRA.Application.Services.Interfaces
{
    public interface ICSVApplicationService : IApplicationService
    {
        Task<Response> Import(IList<CsvDTO> csv);
    }
}

using System.Collections.Generic;
using Textor.GRA.Application.DTOs;
using Textor.GRA.Application.Services.Interfaces.Base;
using Textor.GRA.Domain.Framework.Response;

namespace Textor.GRA.Application.Services.Interfaces
{
    public interface ICsvApplicationService : IApplicationService
    {
        Response Import(IList<CsvDTO> csv);
    }
}

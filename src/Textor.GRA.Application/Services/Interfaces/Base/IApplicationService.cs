using System;
using Textor.GRA.Domain.Repositories.Base;
using Textor.GRA.Domain.Services.Interfaces.Base;

namespace Textor.GRA.Application.Services.Interfaces.Base
{
    public interface IApplicationService
    {
    }

    public interface IApplicationService<TDomainService, TReadRepository> : IApplicationService
        where TDomainService : IDomainService
        where TReadRepository : IReadRepository
    {
    }
}

using Textor.GRA.Application.Services.Interfaces.Base;
using Textor.GRA.Domain.Repositories.Base;
using Textor.GRA.Domain.Services.Interfaces.Base;

namespace Textor.GRA.Application.Services.Base
{
    public class ApplicationService : IApplicationService
    {
        public void Dispose()
        {
        }
    }

    public class ApplicationService<TDomainService, TReadRepository> : IApplicationService<TDomainService, TReadRepository>
        where TDomainService : IDomainService
        where TReadRepository : IReadRepository
    {
        public readonly TDomainService DomainService;
        public readonly TReadRepository Repository;

        public ApplicationService(TDomainService domainService, TReadRepository repository)
        {
            DomainService = domainService;
            Repository = repository;
        }

        public void Dispose()
        {

        }
    }
}

using Textor.GRA.Domain.Entities;
using Textor.GRA.Domain.Framework.Response;
using Textor.GRA.Domain.Repositories;
using Textor.GRA.Domain.Services.Base;
using Textor.GRA.Domain.Services.Interfaces;

namespace Textor.GRA.Domain.Services
{
    public class ProducerService : DomainService<Producer, IProducerWriteRepository>, IProducerService
    {
        public ProducerService(IProducerWriteRepository repository) : base(repository)
        {
        }

        public override Response Add(Producer entity)
        {
            entity.NewGuid();

            return base.Add(entity);
        }
    }
}

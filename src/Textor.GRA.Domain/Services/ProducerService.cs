using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Textor.GRA.Domain.Entities;
using Textor.GRA.Domain.Framework.Response;
using Textor.GRA.Domain.Repositories;
using Textor.GRA.Domain.Services.Base;
using Textor.GRA.Domain.Services.Interfaces;

namespace Textor.GRA.Domain.Services
{
    public class ProducerService : DomainService<Producer, IProducerWriteRepository>, IProducerService
    {
        private readonly IProducerReadRepository ReadRepository;

        public ProducerService(IProducerWriteRepository repository, IProducerReadRepository readRepository) : base(repository)
        {
            ReadRepository = readRepository;
        }

        public override async Task<Response> Add(Producer entity)
        {
            return await Repository.Add(entity);
        }

        public override async Task<Response> AddRange(IList<Producer> entities)
        {
            var registers = new List<Producer>();

            foreach (var item in entities)
            {
                if (!ReadRepository.Get(c => c.Name == item.Name).Any())
                    registers.Add(item);
            }

            var ret1 = await base.AddRange(registers);

            return await Repository.SaveChanges();
        }
    }
}

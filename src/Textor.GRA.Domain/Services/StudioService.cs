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
    public class StudioService : DomainService<Studio, IStudioWriteRepository>, IStudioService
    {
        private readonly IStudioReadRepository ReadRepository;

        public StudioService(IStudioWriteRepository repository, IStudioReadRepository readRepository) : base(repository)
        {
            ReadRepository = readRepository;
        }

        public override async Task<Response> Add(Studio entity)
        {
            return await Repository.Add(entity);
        }

        public override async Task<Response> AddRange(IList<Studio> entities)
        {
            var registers = new List<Studio>();

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

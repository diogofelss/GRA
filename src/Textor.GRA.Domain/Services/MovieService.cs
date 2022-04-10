using System.Collections.Generic;
using System.Linq;
using Textor.GRA.Domain.Entities;
using Textor.GRA.Domain.Framework.Response;
using Textor.GRA.Domain.Repositories;
using Textor.GRA.Domain.Services.Base;
using Textor.GRA.Domain.Services.Interfaces;

namespace Textor.GRA.Domain.Services
{
    public class MovieService : DomainService<Movie, IMovieWriteRepository>, IMovieService
    {
        private readonly IMovieReadRepository ReadRepository;

        public MovieService(IMovieWriteRepository repository, IMovieReadRepository readRepository) : base(repository)
        {
            ReadRepository = readRepository;
        }

        public override Response Add(Movie entity)
        {
            var ret = Repository.Add(entity);

            return Repository.SaveChanges();
        }

        public override Response AddRange(IList<Movie> entities)
        {
            var registers = new List<Movie>();

            foreach (var item in entities)
            {
                if (!ReadRepository.Get(c => c.Title == item.Title && c.Year == item.Year).Any())
                    registers.Add(item);
            }

            var ret1 = base.AddRange(registers);

            return Repository.SaveChanges();
        }

        public Response AddProducer(MovieProducer producer)
        {
            return Repository.AddProducer(producer);
        }

        public Response AddStudio(MovieStudio studio)
        {
            return Repository.AddStudio(studio);
        }
    }
}

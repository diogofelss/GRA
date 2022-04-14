using System;
using System.Collections.Generic;
using System.Linq;
using Textor.GRA.Domain.Entities;
using Textor.GRA.Domain.Repositories.Base;

namespace Textor.GRA.Domain.Repositories
{
    public interface IProducerReadRepository : IReadRepository<Producer>
    {
        IQueryable<Producer> GetInterval();
        IQueryable<MovieProducer> GetMovieProducers();
    }
}

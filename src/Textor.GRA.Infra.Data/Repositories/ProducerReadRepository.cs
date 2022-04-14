using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Textor.GRA.Domain.Entities;
using Textor.GRA.Domain.Repositories;
using Textor.GRA.Infra.Data.Context;
using Textor.GRA.Infra.Data.Repositories.Base;

namespace Textor.GRA.Infra.Data.Repositories
{
    public class ProducerReadRepository : Repository<GeneralContext>, IProducerReadRepository
    {
        public ProducerReadRepository(GeneralContext context) : base(context)
        {

        }

        public IQueryable<Producer> Get()
        {
            return Context.Producers;
        }

        public IQueryable<Producer> Get(Expression<Func<Producer, bool>> predicate)
        {
            return Context.Producers.Where(predicate);
        }

        public IQueryable<Producer> GetInterval()
        {
            var query = from m in Context.Movies
                         join mp in Context.MovieProducers on m.ID equals mp.MovieID
                         join p in Context.Producers on mp.ProducerID equals p.ID
                         where m.Winner == true
                        select p;

            return query;
        }

        public IQueryable<MovieProducer> GetMovieProducers()
        {
            return Context.MovieProducers;
        }

        public IQueryable<Producer> Sql(string query)
        {
            throw new NotImplementedException();
        }
    }
}

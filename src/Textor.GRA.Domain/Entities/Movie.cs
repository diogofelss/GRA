using System;
using System.Collections.Generic;
using Textor.GRA.Domain.Entities.Base;

namespace Textor.GRA.Domain.Entities
{
    public class Movie : Entity<Guid>
    {
        public Movie()
        {
            ID = Guid.NewGuid();
            Producers = new List<MovieProducer>();
            Studios = new List<MovieStudio>();
        }

        public int Year { get; set; }
        public string Title { get; set; }
        public bool Winner { get; set; }

        #region Navigation

        public virtual IList<MovieProducer> Producers { get; private set; }
        public virtual IList<MovieStudio> Studios { get; private set; }

        #endregion

        #region Methods

        public void NewGuid()
        {
            ID = Guid.NewGuid();
        }

        public void AddProducer(Guid producerID)
        {
            Producers.Add(new MovieProducer
            {
                MovieID = ID,
                ProducerID = producerID
            });
        }

        public void AddStudio(Guid studioID)
        {
            Studios.Add(new MovieStudio
            {
                MovieID = ID,
                StudioID = studioID
            });
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using Textor.GRA.Domain.Entities.Base;

namespace Textor.GRA.Domain.Entities
{
    public class Movie : Entity<Guid>
    {
        public int Year { get; set; }
        public string Title { get; set; }
        public bool Winner { get; set; }

        #region Navigation

        public virtual IList<MovieProducer> Producers { get; set; }
        public virtual IList<MovieStudio> Studios { get; set; }

        #endregion

        #region Methods

        public void NewGuid()
        {
            ID = Guid.NewGuid();
        }

        #endregion
    }
}

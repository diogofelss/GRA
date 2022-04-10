using System;
using Textor.GRA.Domain.Entities.Base;

namespace Textor.GRA.Domain.Entities
{
    public class MovieProducer : Entity<Guid>
    {
        public MovieProducer()
        {
            ID = Guid.NewGuid();
        }

        public Guid MovieID { get; set; }
        public Guid ProducerID { get; set; }

        #region Navigation

        public virtual Movie Movie { get; set; }
        public virtual Producer Producer { get; set; }

        #endregion

        #region Methods

        public void NewGuid()
        {
            ID = Guid.NewGuid();
        }

        #endregion
    }
}

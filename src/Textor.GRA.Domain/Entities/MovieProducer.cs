using System;
using System.ComponentModel.DataAnnotations;
using Textor.GRA.Domain.Entities.Base;

namespace Textor.GRA.Domain.Entities
{
    public class MovieProducer : Entity<Guid>
    {
        public Guid MovieID { get; set; }
        public Guid ProducerID { get; set; }

        #region Navigation

        public virtual Movie Movie { get; set; }
        public virtual Producer Producer { get; set; }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using Textor.GRA.Domain.Entities.Base;

namespace Textor.GRA.Domain.Entities
{
    public class Producer : Entity<Guid>
    {
        public string Name { get; set; }

        #region Navigation

        public virtual IList<MovieProducer> Movies { get; set; }

        #endregion

        #region Methods

        public void NewGuid()
        {
            ID = Guid.NewGuid();
        }

        #endregion
    }
}

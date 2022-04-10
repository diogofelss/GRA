using System;
using System.Collections.Generic;
using Textor.GRA.Domain.Entities.Base;

namespace Textor.GRA.Domain.Entities
{
    public class Studio : Entity<Guid>
    {
        public Studio()
        {
            ID = Guid.NewGuid();
        }

        public string Name { get; set; }

        #region Navigation

        public virtual IList<MovieStudio> Movies { get; set; }

        #endregion

        #region Methods

        public void NewGuid()
        {
            ID = Guid.NewGuid();
        }

        #endregion
    }
}

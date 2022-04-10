using System;
using System.ComponentModel.DataAnnotations;
using Textor.GRA.Domain.Entities.Base;

namespace Textor.GRA.Domain.Entities
{
    public class MovieStudio : Entity<Guid>
    {
        public Guid MovieID { get; set; }
        public Guid StudioID { get; set; }

        #region Navigation

        public virtual Movie Movie { get; set; }
        public virtual Studio Studio { get; set; }

        #endregion
    }
}

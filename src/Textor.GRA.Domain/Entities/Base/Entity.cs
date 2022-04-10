using Textor.GRA.Domain.Entities.Interfaces;

namespace Textor.GRA.Domain.Entities.Base
{
    public abstract class Entity : IEntity
    {
    }

    public abstract class Entity<T> : Entity, IEntity<T> where T : struct
    {
        public T ID { get; protected set; }
    }
}

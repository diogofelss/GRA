namespace Textor.GRA.Domain.Entities.Interfaces
{
    public interface IEntity
    {

    }

    public interface IEntity<T> : IEntity where T : struct
    {
    }
}

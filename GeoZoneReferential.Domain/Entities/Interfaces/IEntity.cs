namespace GeoZoneReferential.Domain.Entities.Interfaces
{
    /// <summary>
    /// Represent a object which is persist
    /// </summary>
    public interface IEntity
    {
        int Id { get; set; }

        int ParentId { get; }
    }
}
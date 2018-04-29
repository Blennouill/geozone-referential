namespace GeoZoneReferential.Domain.Entities.Interfaces
{
    /// <summary>
    /// Represent a object which is persist
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Id of the entity
        /// </summary>
        int Id { get; set; }
    }
}
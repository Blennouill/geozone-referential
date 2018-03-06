namespace GeoZoneReferential.Domain.Entities.Interfaces
{
    /// <summary>
    /// Represent a object which has a parent
    /// </summary>
    public interface IEntityHasParent
    {
        int ParentId { get; }
    }
}
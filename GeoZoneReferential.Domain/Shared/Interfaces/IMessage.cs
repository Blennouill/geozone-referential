namespace GeoZoneReferential.Domain.Shared.Interfaces
{
    /// <summary>
    /// Is used to define a type of message which is transmitted through the logic
    /// </summary>
    public interface IMessage
    {
        string Value { get; set; }
    }
}
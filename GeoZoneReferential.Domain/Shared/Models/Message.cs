using GeoZoneReferential.Domain.Shared.Interfaces;

namespace GeoZoneReferential.Domain.Shared.Models
{
    /// <summary>
    /// Represent an information to return to the user
    /// </summary>
    public class Message : IMessage
    {
        public string Value { get; set; }

        public Message(string value)
        {
            Value = value;
        }
    }
}
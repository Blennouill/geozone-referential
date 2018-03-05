using System.Collections.Generic;

namespace GeoZoneReferential.Core.Shared.Models
{
    /// <summary>
    /// Is used to represent an email message
    /// </summary>
    public class EmailMessage
    {
        public List<EmailAddress> To { get; set; }
        public List<EmailAddress> From { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public EmailMessage()
        {
            To = new List<EmailAddress>();
        }
    }
}
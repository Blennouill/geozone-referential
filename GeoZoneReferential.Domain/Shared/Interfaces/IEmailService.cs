using GeoZoneReferential.Core.Shared.Models;

namespace GeoZoneReferential.Domain.Shared.Interfaces
{
    /// <summary>
    /// Email service
    /// </summary>
    public interface IEmailService
    {
        void Send(EmailMessage emailMessage);
    }
}
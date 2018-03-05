using GeoZoneReferential.Domain.Shared.Interfaces;
using System.Collections.Generic;

namespace GeoZoneReferential.Domain.Interfaces
{
    /// <summary>
    /// Is used to manage message trough the application
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Check if the current operation has no errors
        /// </summary>
        /// <returns></returns>
        bool IsValidOperation();

        /// <summary>
        /// Is used to add a new message in the current operation
        /// </summary>
        /// <param name="message">the message to add</param>
        void AddMessage(IMessage message);

        /// <summary>
        /// Is used to return all the message from the current operation
        /// </summary>
        /// <returns></returns>
        IList<IMessage> GetMessages();
    }
}
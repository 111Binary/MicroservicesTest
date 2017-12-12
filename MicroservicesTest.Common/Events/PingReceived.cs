using System;

namespace MicroservicesTest.Common.Events
{
    public class PingReceived : IEvent
    {
        public string VehicleId { get; }
        public DateTime ReceivedAt { get; }

        protected PingReceived()
        {
        }

        public PingReceived(string vehicleId, DateTime receivedAt)
        {
            VehicleId = vehicleId;
            ReceivedAt = receivedAt;
        }
    }
}
using System;

namespace MicroservicesTest.Common.Events
{
    public class PigRejected : IRejectedEvent
    {
        public string VehicleId { get; }
        public DateTime ReceivedAt { get; }

        public string Reason { get; }
        public string Code { get; }

        protected PigRejected()
        {
        }

        public PigRejected(string vehicleId, DateTime receivedAt,string reason,string code)
        {
            VehicleId = vehicleId;
            ReceivedAt = receivedAt;
            Reason = reason;
            Code = code;
        }
    }
}
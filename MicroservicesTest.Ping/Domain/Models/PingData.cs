using System;
using MicroservicesTest.Common.Exceptions;

namespace MicroservicesTest.Ping.Domain.Models
{
    public class PingData
    {
        public Guid Id { get; protected set; }
        public string VehicleId { get; protected set; }

        public DateTime RecivedAt { get; set; }

        protected PingData()
        {
        }

        public PingData(Guid id, string vehicleId, DateTime recivedAt)
        {
            if (string.IsNullOrWhiteSpace(vehicleId))
            {
                throw new MicroservicesTestException("empty_activity_name", 
                    "Activity name can not be empty.");
            }
            Id = id;
            VehicleId = vehicleId;
            RecivedAt = recivedAt;
        }
    }
}
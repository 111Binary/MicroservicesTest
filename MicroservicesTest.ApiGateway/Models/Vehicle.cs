using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicesTest.ApiGateway.Models
{
    public class Vehicle
    {
        public Guid CustomerId { get; set; }
        public string VehicleId { get; set; }
        public string RegNo { get; set; }

        public bool LatestStatus { get; set; }

        public DateTime? LatestPingAt { get; set; }

        public Vehicle(Guid customerId,string vehicleId,string regNo)
        {
            CustomerId = customerId;
            VehicleId = vehicleId;
            RegNo = regNo;
            LatestStatus = false;
            LatestPingAt = null;
        }

    }
}

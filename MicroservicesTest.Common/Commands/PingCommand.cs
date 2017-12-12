using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicesTest.Common.Commands
{
    public class PingCommand:ICommand
    {
        public string VehicleId { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}

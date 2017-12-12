using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicesTest.ApiGateway.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Customer(Guid id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MicroservicesTest.ApiGateway.Models;
using MicroservicesTest.ApiGateway.Repositories;
using MicroservicesTest.Common.Mongo;

using MongoDB.Driver;
using Newtonsoft.Json;

namespace MicroservicesTest.ApiGateway.Services
{
    public class CustomMongoSeeder : MongoSeeder
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ICustomerRepository _customerRepository;

        public CustomMongoSeeder(IMongoDatabase database, IVehicleRepository vehicleRepository, ICustomerRepository customerRepository)
            : base(database)
        {
            _vehicleRepository = vehicleRepository;
            _customerRepository = customerRepository;
        }

        protected override async Task CustomSeedAsync()
        {
            var rootPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            Console.WriteLine($"START Seeding MicroservicesTest.ApiGateway From :{rootPath}");

            var CustomersJson = @"[
                                      {
                                        'Id': 'e43c5a9e-6bd9-4d89-bf1a-014e09868210',
                                        'Name': 'Kalles Grustransporter AB',
                                        'Address': 'Cementvägen 8, 111 11 Södertälje'
                                      },
                                      {
                                        'Id': 'd6e2e016-9f07-4e08-b018-7d8d21fe73d1',
                                        'Name': 'Johans Bulk AB',
                                        'Address': 'Balkvägen 12, 222 22 Stockholm'
                                      },
                                      {
                                        'Id': 'fd267078-3516-4332-a0ec-69c12ce862aa',
                                        'Name': 'Haralds Värdetransporter AB',
                                        'Address': 'Budgetvägen 1, 333 33 Uppsala '
                                      }
                                    ]";
            //File.ReadAllText(rootPath+@"\SeedData\CustomersData.json");
            var Customers = JsonConvert.DeserializeObject<List<Customer>>(CustomersJson);

            await Task.WhenAll(Customers.Select(x => _customerRepository
                        .AddAsync(new Customer(x.Id, x.Name, x.Address))));

            var VehiclesJson = @"[
                                  {
                                    'CustomerId': 'e43c5a9e-6bd9-4d89-bf1a-014e09868210',
                                    'VehicleId': 'YS2R4X20005399401',
                                    'RegNo': 'ABC123',
                                    'LatestStatus': false,
                                    'LatestPingAt': null
                                  },
                                  {
                                    'CustomerId': 'e43c5a9e-6bd9-4d89-bf1a-014e09868210',
                                    'VehicleId': 'VLUR4X20009093588',
                                    'RegNo': 'DEF456',
                                    'LatestStatus': false,
                                    'LatestPingAt': null
                                  },
                                  {
                                    'CustomerId': 'e43c5a9e-6bd9-4d89-bf1a-014e09868210',
                                    'VehicleId': 'VLUR4X20009048066',
                                    'RegNo': 'GHI789',
                                    'LatestStatus': false,
                                    'LatestPingAt': null
                                  },
                                  {
                                    'CustomerId': 'd6e2e016-9f07-4e08-b018-7d8d21fe73d1',
                                    'VehicleId': 'YS2R4X20005388011',
                                    'RegNo': 'JKL012      ',
                                    'LatestStatus': false,
                                    'LatestPingAt': null
                                  },
                                  {
                                    'CustomerId': 'd6e2e016-9f07-4e08-b018-7d8d21fe73d1',
                                    'VehicleId': 'YS2R4X20005387949',
                                    'RegNo': 'MNO345',
                                    'LatestStatus': false,
                                    'LatestPingAt': null
                                  },
                                  {
                                    'CustomerId': 'fd267078-3516-4332-a0ec-69c12ce862aa',
                                    'VehicleId': 'YS2R4X20005387765',
                                    'RegNo': 'PQR678      ',
                                    'LatestStatus': false,
                                    'LatestPingAt': null
                                  },
                                  {
                                    'CustomerId': 'fd267078-3516-4332-a0ec-69c12ce862aa',
                                    'VehicleId': 'YS2R4X20005387055',
                                    'RegNo': 'STU901      ',
                                    'LatestStatus': false,
                                    'LatestPingAt': null
                                  }
                                ]
                                ";
            
            
            // File.ReadAllText(rootPath + @"\SeedData\VehiclesData.json");
            var Vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(VehiclesJson);

            await Task.WhenAll(Vehicles.Select(x => _vehicleRepository
                        .AddAsync(new Vehicle(x.CustomerId, x.VehicleId, x.RegNo))));

            Console.WriteLine($"END Seeding MicroservicesTest.ApiGateway");
        }
    }
}
(function () {

    angular
        .module('app')
        .controller('HomeController', ['$scope', '$http', '$timeout', function ($scope, $http, $timeout) {
            var vm = this;

            $http.get("http://localhost:8091/customers/")
                .then(function (response) {
                    console.log('customers');
                    console.log(response);
                    vm.customers = response.data;
                });

            

            vm.getVehiclesData = function () {
                console.log('getVehiclesData');
                $http.get("http://localhost:8091/vehicles/")
                    .then(function (response) {
                        console.log('vehicles');
                        console.log(response);
                        vm.vehicles = response.data;
                        $timeout(function () { vm.getVehiclesData(); }, 10000);
                    });
                
            }
            vm.simulatePing = function (vehicle) {
                console.log(vehicle);
                var data = {
                    'VehicleId': vehicle.vehicleId
                };
                var config = {
                    headers: {
                        'Content-Type': 'application/json; charset=utf-8',
                        'Access-Control-Allow-Origin':'*'
                    }
                };
                $http.post('http://localhost:8090/Ping/', data, { headers: { 'Content-Type': 'application/json' } }).success(function (data, status) { });
                //$http({
                //    method: 'POST',
                //    url: 'http://localhost:8090/Ping/',
                //    data: "VehicleId=" + vehicle.vehicleId,
                //    headers: {
                //        'Content-Type':'application/json'
                //    }
                //}).then(function (success) {
                //    console.log('ping success');
                //}, function (error) {
                //    console.log('ping error');
                //});
            }

            vm.showDate = function (date) {

                var _utc = new Date(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate(), date.getUTCHours(), date.getUTCMinutes(), date.getUTCSeconds());
                return _utc;

            }
            vm.NowUTC = moment();

            vm.isOnline = function (vehicle) {
                var statusDate = moment(vehicle.latestPingAt).add(1, 'minutes');
                if (!angular.isUndefined(statusDate) && statusDate !=null) {
                    if (statusDate >= moment()) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                return false;

            };
            
            vm.getVehiclesData();
            
        }
        ]);


})();

(function () {

    angular
        .module('app')
        .controller('HomeController', ['$scope', '$http', '$timeout', function ($scope, $http, $timeout) {
            var vm = this;
            vm.CommandBaseURL = '';
            vm.QueryBaseURL = '';

            $http.get("/Home/Settings")
                .then(function (response) {
                    vm.CommandBaseURL = response.data.commandBaseURL;
                    vm.QueryBaseURL = response.data.queryBaseURL;

                    vm.getCustomers();
                    vm.getVehiclesData();
                });

            vm.getCustomers = function () {
                $http.get(vm.QueryBaseURL+"/customers/")
                    .then(function (response) {
                        vm.customers = response.data;
                    });
            }
            
            vm.getVehiclesData = function () {
                $http.get(vm.QueryBaseURL +"/vehicles/")
                    .then(function (response) {

                        vm.vehicles = response.data;
                        $timeout(function () { vm.getVehiclesData(); }, 10000);
                    });
                
            }
            vm.simulatePing = function (vehicle) {

                var data = {
                    'VehicleId': vehicle.vehicleId
                };
                var config = {
                    headers: {
                        'Content-Type': 'application/json; charset=utf-8',
                        'Access-Control-Allow-Origin':'*'
                    }
                };
                $http.post(vm.CommandBaseURL + '/Ping/', data, { headers: { 'Content-Type': 'application/json' } }).success(function (data, status) { });
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
            
        }
        ]);


})();

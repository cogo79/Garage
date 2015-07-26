angularGarageApp.controller("VehiclesSummaryController",
    ["$scope", "DataService",
    function ($scope, DataService) {

        DataService.getAllVehicles().then(
            function (results) {
                // on success
                $scope.vehicles = results.data;
            },
            function (results) {
                // on error
                console.log(results.data);
            }
        );

        DataService.getVehicleTypes().then(
            function (results) {
                // on success
                $scope.vehicleTypes = results.data;
            },
            function (results) {
                // on error
                console.log(results.data);
            }
        );
    }]);


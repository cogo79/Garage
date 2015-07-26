
angularGarageApp.factory('DataService',
    ["$http",
    function ($http) {

        var getAllVehicles = function () {
            return $http.get("VehiclesSummary/GetAllVehicles");
        };

        var getVehicleTypes = function () {
            return $http.get("VehiclesSummary/GetVehicleTypes");
        };

        return {
            getAllVehicles: getAllVehicles,
            getVehicleTypes: getVehicleTypes
        };
    }]);












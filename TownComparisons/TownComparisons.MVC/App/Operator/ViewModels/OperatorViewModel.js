﻿operatorModule.controller("operatorViewModel", function ($scope, operatorService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.operatorService = operatorService;


    var initialize = function () {
        $scope.getOrganisationalUnitInfoByOUId($routeParams.ouId); // testa "V15E128300201"
        //$scope.getOrganisationalUnitInfoByOUId("V15E128300201");
    }
    
    //Get Organisational Unit Info via OperatorController
    $scope.getOrganisationalUnitInfoByOUId = function (ouId) {
        viewModelHelper.apiGet('api/operator/' + ouId, null,
            function (result) {
                $scope.organisationalUnit = result.data;
            });
    }

    //$scope.getOrganisationalUnitInfoByOUId = function (ouId) {
    //    viewModelHelper.apiGet('api/operator/' + ouId, null,
    //        function (result) {
    //            $scope.organisationalUnit = result.data;
    //        });
    //}

    //$scope.showOrder = function () {
    //    if (orderService.orderId != 0) {
    //        $scope.flags.shownFromList = false;
    //        viewModelHelper.navigateTo('operator/' + orderService.orderId);
    //    }
    //}

    initialize();
});
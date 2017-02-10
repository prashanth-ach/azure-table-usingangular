/// <reference path="angular.min.js" />
var app = angular.module("myModule", [])
                 .controller("myController", function ($scope, $http) {
                     $http.post('PrashService.asmx/GetAllData')
                     .then(function (response) {

                         $scope.sri = response.data;

                     });
                 }
                 );
/// <reference path="C:\Users\Denis\Documents\Visual Studio 2015\Projects\RentService\RentService\Lib/angular.min.js" />
//var model = {
//    ad: [
//        {}
//    ]
//};

var app = angular.module('postScreenApp', []);

app.controller('postScreenCtrl', ['$http', '$scope', function ($http, $scope) {

    $scope.method = 'POST';
    $scope.url = 'http://localhost:50591/AdDataService.svc/post/newAd';
    $scope.startrentdate = new Date();
    $scope.finishrentdate = new Date();
    $scope.ad = {
        ItemName: '',
        Description: '',
        City: '',
        StartRentDate: $scope.startrentdate,
        FinishRentDate: $scope.finishrentdate,

        DailyRentPrice: '',
        WeeklyRentPrice: '',
        MonthlyRentPrice: '',
        OwnerName: '',
        PhoneNumber: ''
    };

    $scope.send = function () {

        $http({ method: $scope.method, data: $scope.ad, url: $scope.url }).
        then(function (response) {
            $scope.status = response.status;
            $scope.data = response.data;
        }, function (response) {
            $scope.data = response.data || "Request failed";
            $scope.status = response.status;
        });

    }

}])
(function () {
    var exampleApp = angular.module('Example.ClientControllers', []);

    exampleApp.controller('ClientsController', function ($scope, $rootScope, $http, clientService) {
        $scope.clients = [];

        clientService.getClients().then(function (res) {
            console.log(res);
            $scope.clients = res;
        });
    });
})();
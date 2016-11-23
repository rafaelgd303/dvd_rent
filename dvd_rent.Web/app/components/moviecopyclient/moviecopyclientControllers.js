(function () {
    var exampleApp = angular.module('Example.MovieCopyClientControllers', []);

    exampleApp.controller('MoviesCopyClientController', function ($scope, $rootScope, $http, moviecopyclientService) {
        $scope.moviesCopyClient = [];

        moviecopyclientService.getMoviesCopyClient().then(function (res) {
            console.log(res);
            $scope.moviesCopyClient = res;
        });
    });

    exampleApp.controller('RentCopyController', function (
        $scope,
        $rootScope,
        $http,
        $state,
        moviecopyclientService) {

        $scope.model = {};

        $scope.rent = function () {
            moviecopyclientService.rentMovie($scope.model)
            .then(function (res) {
                $state.go('moviescopyclient');
            })
        }

        angular.element(document).ready(function () {
            $("#moviesList").select2({
                ajax: {
                    url: "api/listMovies",
                    dataType: 'json',
                    delay: 250,
                    data: function (params) {
                        return {
                            search: params.term,
                        };
                    },
                    processResults: function (data, params) {
                        return {
                            results: data
                        };
                    },
                    cache: false
                },
                escapeMarkup: function (markup) { return markup; }, // let our custom formatter work
                minimumInputLength: 1,
            });

            $("#clientsList").select2({
                ajax: {
                    url: "api/listClients",
                    dataType: 'json',
                    delay: 250,
                    data: function (params) {
                        return {
                            search: params.term,
                        };
                    },
                    processResults: function (data, params) {
                        return {
                            results: data
                        };
                    },
                    cache: false
                },
                escapeMarkup: function (markup) { return markup; }, // let our custom formatter work
                minimumInputLength: 1,
            });
        });
    });

    exampleApp.controller('BackCopyController',
        function (
            $scope,
            $rootScope,
            $http,
            moviecopyclientService) {

            $scope.model = {};
            $scope.clientMoviesCopy = [];
            $scope.alertMsg = '';

            $scope.clientChanged = function (clientId) {
                moviecopyclientService.getClientCopies(clientId)
                    .then(function (data) {
                    $scope.clientMoviesCopy = data;
                });
            }

            $scope.getBack = function () {
                moviecopyclientService.getBackMovie($scope.model).then(function (res) {
                    $scope.alertMsg = 'Client ' + res.client + ' back movie \'' + res.title + '\', copy serial number \'' + res.serialNumber + '\'';
                    $scope.model.clientId = '';
                    $scope.model.movieCopyId = '';
                    $scope.clientMoviesCopy = [];

                    $state.go('moviescopyclient');
                });
            }

            $scope.closeAlert = function () {
                $scope.alertMsg = '';
            }

            angular.element(document).ready(function () {
                $("#clientsList").select2({
                    ajax: {
                        url: "api/listClients",
                        dataType: 'json',
                        delay: 250,
                        data: function (params) {
                            return {
                                search: params.term,
                            };
                        },
                        processResults: function (data, params) {
                            return {
                                results: data
                            };
                        },
                        cache: false
                    },
                    escapeMarkup: function (markup) { return markup; }, // let our custom formatter work
                    minimumInputLength: 1,
                });
            });
        });
})();
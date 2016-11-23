(function () {
    var exampleApp = angular.module('Example.MovieControllers', []);

    exampleApp.controller('MoviesController', function ($scope, $rootScope, $http, $state, movieService) {
        $scope.movies = [];

        $scope.addMovie = function () {
            $state.go('movie');
        }

        movieService.getMovies().then(function (res) {
            $scope.movies = res;
        });
    });

    exampleApp.controller('MovieController', function ($scope, $rootScope, $http, $state, movieService) {
        $scope.model = {};

        $scope.save = function () {
            movieService.save($scope.model)
                .then(function (res) {
                    $state.go('movies');
                });
        }

        //movieService.getMovies().then(function (res) {
        //    $scope.movie = res;
        //});
    });

})();
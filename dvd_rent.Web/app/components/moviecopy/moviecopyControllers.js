(function () {
    var exampleApp = angular.module('Example.MovieCopyControllers', []);

    exampleApp.controller('MoviesCopiesController', function ($scope, $rootScope, $http, $state, moviecopyService) {
        $scope.moviesCopies = [];

        $scope.addMovieCopy = function () {
            $state.go('moviecopy');
        }

        moviecopyService.getMoviesCopies().then(function (res) {
            console.log(res);
            $scope.moviesCopies = res;
        });
    });

    exampleApp.controller('MovieCopyController', function ($scope, $rootScope, $http, $state, moviecopyService, movieService) {
        $scope.model = {};
        $scope.movies = [];

        movieService.getMovies().then(function (res) {
            $scope.movies = res;
        });

        $scope.save = function () {
            moviecopyService.save($scope.model).then(function (res) {
                $state.go('moviescopies');
            });
        }
    });

})();
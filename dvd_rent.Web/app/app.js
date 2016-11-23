(function () {
    'use strict';

    var ExampleApp = angular.module('Example', [
        'ui.router',
        'ui.bootstrap',
        'Example.ApplicationControllers',
        'Example.ClientServices',
        'Example.ClientControllers',
        'Example.MovieServices',
        'Example.MovieControllers',
        'Example.MovieCopyServices',
        'Example.MovieCopyControllers',
        'Example.MovieCopyClientServices',
        'Example.MovieCopyClientControllers',
    ]);

    ExampleApp.config(['$stateProvider', '$urlRouterProvider',
    function ($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('clients', {
                url: '/clients',
                templateUrl: 'app/components/client/list.html',
                controller: 'ClientsController',
                resolve: {
                    clientService: 'clientService',
                },
            })
            .state('movies', {
                url: '/movies',
                templateUrl: 'app/components/movie/list.html',
                controller: 'MoviesController',
                resolve: {
                    movieService: 'movieService',
                },
            })
            .state('movie', {
                url: '/movie',
                templateUrl: 'app/components/movie/details.html',
                controller: 'MovieController',
                resolve: {
                    movieService: 'movieService',
                },
            })
            .state('moviescopies', {
                url: '/moviescopies',
                templateUrl: 'app/components/moviecopy/list.html',
                controller: 'MoviesCopiesController',
                resolve: {
                    moviecopyService: 'moviecopyService',
                },
            })
            .state('moviecopy', {
                url: '/moviecopy',
                templateUrl: 'app/components/moviecopy/details.html',
                controller: 'MovieCopyController',
                resolve: {
                    movieService: 'movieService',
                    moviecopyService: 'moviecopyService',
                },
            })
            .state('moviescopyclient', {
                url: '/moviescopyclient',
                templateUrl: 'app/components/moviecopyclient/list.html',
                controller: 'MoviesCopyClientController',
                resolve: {
                    moviecopyclientService: 'moviecopyclientService',
                },
            })
            .state('rentmovie', {
                url: '/rentmovie',
                templateUrl: 'app/components/moviecopyclient/rent.html',
                controller: 'RentCopyController',
                resolve: {
                    moviecopyclientService: 'moviecopyclientService',
                },
            })
            .state('getbackmovie', {
                url: '/getbackmovie',
                templateUrl: 'app/components/moviecopyclient/getback.html',
                controller: 'BackCopyController',
                resolve: {
                    moviecopyclientService: 'moviecopyclientService',
                },
            })
        //$urlRouterProvider.otherwise('/rentmovie');
        $urlRouterProvider.otherwise('/clients');
    }]);
})();
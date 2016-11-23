(function () {
    'use strict';

    var exampleApp = angular.module("Example.MovieServices", []);

    exampleApp.factory('movieService', function ($http, $log) {
        return {
            getMovies: function () {
                var url = 'api/movie';

                return $http.get(url)
                    .then(function (res) {
                        console.log(res)
                        return res.data;
                    }).catch(
                    function (error) {
                        $log.error('Failed for getMovies.' + error.data);
                        return error.status;
                    });
            },

            save: function (model) {
                var url = 'api/movie';

                return $http.put(url, model)
                    .then(function (res) {
                        return res.data;
                    }).catch(
                    function (error) {
                        return error.status;
                    });
            },
        }
    });
})();
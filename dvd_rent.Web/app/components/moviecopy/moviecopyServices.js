(function () {
    'use strict';

    var exampleApp = angular.module("Example.MovieCopyServices", []);

    exampleApp.factory('moviecopyService', function ($http, $log) {
        return {
            getMoviesCopies: function () {
                var url = 'api/moviecopy';

                return $http.get(url)
                    .then(function (res) {
                        console.log(res)
                        return res.data;
                    }).catch(
                    function (error) {
                        $log.error('Failed for getMoviesCopies.' + error.data);
                        return error.status;
                    });
            },

            save: function (model) {
                var url = 'api/moviecopy';

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
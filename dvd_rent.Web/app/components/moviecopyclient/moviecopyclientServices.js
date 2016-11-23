(function () {
    'use strict';

    var exampleApp = angular.module("Example.MovieCopyClientServices", []);

    exampleApp.factory('moviecopyclientService', function ($http, $log) {
        return {
            rentMovie: function (model) {
                //var url = 'api/rentMovie';
                var url = 'api/moviecopyclient';

                return $http.put(url, model)
                    .then(function (res) {
                        return res.data;
                    }).catch(
                    function (error) {
                        //console.log(error.data);
                        //$log.error('Failed for rentMovie.' + error.data);
                        return error.status;
                    });
            },

            getMoviesCopyClient: function () {
                var url = 'api/moviecopyclient';

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

            getClientCopies: function (clientId) {
                var url = 'api/clientCopies?clientId=' + clientId;
                //var url = 'api/moviecopyclient?clientId=' + clientId;

                return $http.get(url)
                    .then(function (res) {
                        return res.data;
                    }).catch(
                    function (error) {
                        $log.error('Failed for userClientCopies.' + error.data);
                        return error.status;
                    });
            },

            getBackMovie: function (model) {
                //var url = 'api/rentMovie';
                var url = 'api/moviecopyclient';
                console.dir(model);

                return $http.post(url, model)
                    .then(function (res) {
                        return res.data;
                    }).catch(
                    function (error) {
                        //console.log(error.data);
                        //$log.error('Failed for rentMovie.' + error.data);
                        return error.status;
                    });
            },
        }
    });
})();
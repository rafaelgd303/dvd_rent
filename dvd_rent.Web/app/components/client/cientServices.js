(function () {
    'use strict';

    var exampleApp = angular.module("Example.ClientServices", []);

    exampleApp.factory('clientService', function ($http, $log) {
        return {
            getClients: function () {
                var url = 'api/client';

                return $http.get(url)
                    .then(function (res) {
                        console.log(res)
                        return res.data;
                    }).catch(
                    function (error) {
                        $log.error('Failed for getClients.' + error.data);
                        return error.status;
                    });
            },
        }
    });
})();
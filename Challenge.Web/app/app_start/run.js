(function () {

    'use strict';

    angular.module('app').run(function ($rootScope, $location, SETTINGS) {

        var token = sessionStorage.getItem(SETTINGS.AUTH_TOKEN);

        $rootScope.token = null;

        if (token) {
            $rootScope.token = token;
            $rootScope.header = {
                headers: {
                    'Authorization': 'Bearer ' + token
                }
            }
        }

        $rootScope.$on('$routeChangeStart', function (event, next, current) {
            if ($rootScope.token == null) {
                $location.path("/login");
            }
        });
    });

})();
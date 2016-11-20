(function () {

    'use strict';

    angular.module('app').factory('AccountFactory', AccountFactory);

    AccountFactory.$inject = ['$http', 'SETTINGS'];

    function AccountFactory($http, SETTINGS) {
        return {
            login: login
        };

        function login(data) {

            var url = SETTINGS.ACCESS_URL + 'api/security/token';
            var dt = "grant_type=password&username=" + data.privateKey + "&password=" + data.publicKey;
            var header = { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } };

            return $http.post(url, dt, header);
        }
    }
})();
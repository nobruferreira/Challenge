(function () {

    'use strict';

    angular.module('app').controller('LogoutCtrl', LogoutCtrl);

    LogoutCtrl.$inject = ['$rootScope', '$location', 'SETTINGS'];

    function LogoutCtrl($rootScope, $location, SETTINGS) {

        var vm = this;

        activate();

        function activate() {
            $rootScope.token = null;
            sessionStorage.removeItem(SETTINGS.AUTH_TOKEN);
            sessionStorage.removeItem(SETTINGS.AUTH_PRIVATE_KEY);
            sessionStorage.removeItem(SETTINGS.AUTH_PUBLIC_KEY);

            $location.path('/login');
        }
    }

})();
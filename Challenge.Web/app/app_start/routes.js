(function () {

    'use strict';

    angular.module('app').config(function ($routeProvider) {

        $routeProvider

            // Login
            .when('/login', {
                controller: 'LoginCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/components/login/login.html'
            })
            .when('/logout', {
                controller: 'LogoutCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/components/login/login.html'
            })

             // Character
            .when('/character', {
                controller: 'CharacterCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/components/character/character.html'
            })

            .otherwise({
                redirectTo: '/character'
            });
    });

})();
(function () {

    'use strict';
    angular.module('app').controller('LoginCtrl', LoginCtrl);

    LoginCtrl.$inject = ['$rootScope', '$location', 'AccountFactory', 'SETTINGS'];

    function LoginCtrl($rootScope, $location, AccountFactory, SETTINGS) {

        var vm = this;
          
        vm.preloader = false;

        //POST
        vm.login = {
            privateKey: '',
            publicKey: ''
        };

        // FUNCTIONS
        vm.submit = submit;

        function submit() {

            vm.preloader = true;

            AccountFactory.login(vm.login)
                .success(success)
                .catch(fail);

            function success(response) {
                $rootScope.token = response.access_token;
                sessionStorage.setItem(SETTINGS.AUTH_TOKEN, response.access_token);
                sessionStorage.setItem(SETTINGS.AUTH_PRIVATE_KEY, vm.login.privateKey);
                sessionStorage.setItem(SETTINGS.AUTH_PUBLIC_KEY, vm.login.publicKey);

                vm.preloader = false;
                $location.path('/character');
            }

            function fail(error) {
                toastr.error(error.data.error_description, 'Falha na autenticação com a MarvelApi');
                vm.preloader = false;
            }
        }
    }

})();

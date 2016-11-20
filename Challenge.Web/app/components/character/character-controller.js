(function () {

    'use strict';
    angular.module('app').controller('CharacterCtrl', CharacterCtrl);

    CharacterCtrl.$inject = ['$scope', 'CharacterFactory', '$location', '$rootScope', '$uibModal', '$log', 'SETTINGS'];

    function CharacterCtrl($scope, CharacterFactory, $location, $rootScope, $uibModal, $log, SETTINGS) {

        var vm = this;

        vm.listCharacter = [];
        vm.listComicsByCharacterId = [];

        vm.showSearch = false;

        vm.thumbnailComicsByCharacterId = '';
        vm.nameComicsByCharacterId = '';
        vm.descriptionComicsByCharacterId = '';

        //PAGINATION
        vm.totalCharacters = 0;
        vm.currentPage = 1;
        vm.maxSize = 7;

        //MODAL
        vm.animationsEnabled = true;

        //POST
        vm.dataGetCharacter = {
            privateKey: sessionStorage.getItem('cha-private-key'),
            publicKey: sessionStorage.getItem('cha-public-key'),
            skip: '0',
            take: '10'
        };

        vm.dataGetComicsByCharacterId = {
            privateKey: sessionStorage.getItem('cha-private-key'),
            publicKey: sessionStorage.getItem('cha-public-key'),
            characterId: 0
        };

        //FUNCTIONS
        vm.setPage = setPage;
        vm.openModal = openModal;

        activate();

        function activate() {
            getCharacter(vm.dataGetCharacter);
        }

        function getCharacter(data) {

            CharacterFactory.getCharacter(data)
               .success(success)
               .catch(fail);

            function success(response) {

                if (response.status != 'Ok') {
                    toastr.error('Falha ao recuperar os personagens da MarvelApi', 'Erro');
                    $location.path('/login');
                }

                vm.listCharacter = response.data.results;
                vm.showSearch = true;
                vm.totalCharacters = response.data.total;
                $location.path('/character');
            }

            function fail(error) {

                toastr.error(error.data.error_description, 'Falha ao recuperar os personagens da MarvelApi');
                $location.path('/login');
            }
        }

        function setPage(pageNumber) {

            vm.dataGetCharacter = {
                privateKey: sessionStorage.getItem('cha-private-key'),
                publicKey: sessionStorage.getItem('cha-public-key'),
                skip: pageNumber - 1,
                take: '10'
            };

            getCharacter(vm.dataGetCharacter);
        }

        function getComicsByCharacterId(data) {

            CharacterFactory.getComicsByCharacterId(data)
               .success(success)
               .catch(fail);

            function success(response) {

                if (response.status != 'Ok') {
                    toastr.error('Falha ao recuperar os detalhes do personagem da MarvelApi', 'Erro');
                    $location.path('/login');
                }

                vm.listComicsByCharacterId = response;
            }

            function fail(error) {

                toastr.error(error.data.error_description, 'Falha ao recuperar os detalhes do personagem da MarvelApi');
                $location.path('/login');
            }
        }

        function openModal(characterId, size, thumbnailPath, thumbnailExtension, name, description) {

            vm.thumbnailComicsByCharacterId = thumbnailPath + '.' + thumbnailExtension;
            vm.nameComicsByCharacterId = name;
            vm.descriptionComicsByCharacterId = description;

            vm.dataGetComicsByCharacterId = {
                privateKey: sessionStorage.getItem('cha-private-key'),
                publicKey: sessionStorage.getItem('cha-public-key'),
                characterId: characterId
            };

            getComicsByCharacterId(vm.dataGetComicsByCharacterId);

            var scope = $scope.$new();
            scope.factory = CharacterFactory;

            var modalInstance = $uibModal.open({
                scope: scope,
                animation: vm.animationsEnabled,
                templateUrl: 'app/components/character/modal/details-modal.html',
                controller: 'ModalInstanceCtrl',
                size: size,
                resolve: {
                    items: function () {
                        return null;
                    }
                }
            });
        }
    }

    angular.module('app').controller('ModalInstanceCtrl', ModalInstanceCtrl);

    ModalInstanceCtrl.$inject = ['$scope', '$uibModalInstance', 'items'];

    function ModalInstanceCtrl($scope, $uibModalInstance, items) {

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };
    }

})();
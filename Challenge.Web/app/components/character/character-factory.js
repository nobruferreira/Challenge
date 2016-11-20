(function () {

    'use strict';

    angular.module('app').factory('CharacterFactory', CharacterFactory);

    CharacterFactory.$inject = ['$rootScope', '$http', 'SETTINGS'];

    function CharacterFactory($rootScope, $http, SETTINGS) {

        return {
            getCharacter: getCharacter,
            getComicsByCharacterId: getComicsByCharacterId
        };

        function getCharacter(data) {

            $rootScope.header = {
                headers: {
                    'Authorization': 'Bearer ' + $rootScope.token
                }
            }

            return $http.post(SETTINGS.ACCESS_URL + 'api/character/list', data, $rootScope.header);
        }

        function getComicsByCharacterId(data) {
            return $http.post(SETTINGS.ACCESS_URL + 'api/character/list/comics/characterId', data, $rootScope.header);
        }
    }

})();
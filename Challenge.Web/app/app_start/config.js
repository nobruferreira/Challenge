(function () {

    'use strict';

    angular.module('app').constant('SETTINGS', {
        'VERSION': '0.0.1',
        'CURR_ENV': 'dev',
        'AUTH_PRIVATE_KEY': 'cha-private-key',
        'AUTH_PUBLIC_KEY': 'cha-public-key',
        'AUTH_TOKEN': 'cha-token',
        'ACCESS_URL': 'http://localhost:5866/'
    });

    angular.module('app').filter('parseToHtml', function ($sce) {
        return function (val) {
            return $sce.trustAsHtml(val);
        };
    });

})();
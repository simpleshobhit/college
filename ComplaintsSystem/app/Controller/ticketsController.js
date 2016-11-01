(function () {
    'use strict';

    angular
        .module('app')
        .controller('ticketsController', tickets);

    function tickets() {
        var tc = this;
        vm.food = 'pizza';
    }

})();
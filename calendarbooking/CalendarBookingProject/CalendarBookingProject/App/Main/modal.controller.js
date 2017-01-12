(function () {
    'use strict'

    angular
        .module("app.main")
        .controller("ModalController", ModalController);

    ModalController.$inject = ["$uibModalInstance", "clientEvents"];

    function ModalController($uibModalInstance, clientEvents) {
        var vm = this;
        vm.isBookedFirstPart = false;
        vm.isBookedSecondPart = false;
        vm.isBookedThirdPart = false;
        vm.firstPart;
        vm.secondPart;
        vm.thirdPart;

        for (var i = 0; i < clientEvents.length; i++) {
            if (i == 0) {
                vm.isBookedFirstPart = moment(clientEvents[i].start).format("HH") == '24' ? true : false;
            }
            else if (i == 1) {
                vm.isBookedSecondPart = moment(clientEvents[i].start).format("HH") == '08' ? true : false;
            }
            else if (i == 2) {
                vm.isBookedThirdPart = moment(clientEvents[i].start).format("HH") == '16' ? true : false;
            }
        }

        vm.save = save;
        vm.close = close;

        function save() {

            $uibModalInstance.close(firstPart, secondPart, thirdPart);
        }

        function close() {
            $uibModalInstance.dismiss();
        }
    }
})()
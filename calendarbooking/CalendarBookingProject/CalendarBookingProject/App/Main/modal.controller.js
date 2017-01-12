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
            console.log(clientEvents[i]);
            var hour = moment(clientEvents[i].start).format("HH");
            if (hour == '00') {
                vm.isBookedFirstPart = true;
            }
            else if ( hour == '08') {
                vm.isBookedSecondPart = true;
            }
            else if ( hour == '16') {
                vm.isBookedThirdPart = true;
            }
        }

        console.log(vm.isBookedFirstPart, vm.isBookedSecondPart, vm.isBookedThirdPart)

        vm.save = save;
        vm.close = close;

        function save() {
            if (!vm.isBookedFirstPart && vm.firstPart) {
                console.log("nice 1");
            }
            if (!vm.isBookedSecondPart && vm.secondPart) {
                console.log("nice 2");
            }
            if (!vm.isBookedThirdPart && vm.thirdPart) {
                console.log("nice 3");
            }
            $uibModalInstance.close(vm.firstPart, vm.secondPart, vm.thirdPart);
        }

        function close() {
            $uibModalInstance.dismiss();
        }
    }
})()
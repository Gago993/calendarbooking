(function () {
    'use strict'

    angular
        .module("app.main")
        .controller("ModalController", ModalController);

    ModalController.$inject = ["$uibModalInstance", "clientEvents", "BookingData"];

    function ModalController($uibModalInstance, clientEvents, BookingData) {
        var vm = this;
        vm.isBookedFirstPart = false;
        vm.isBookedSecondPart = false;
        vm.isBookedThirdPart = false;
        vm.firstPart;
        vm.secondPart;
        vm.thirdPart;
        vm.firstPartTime;
        vm.secondPartTime;
        vm.thirdPartTime;
        vm.save = save;
        vm.close = close;
        console.log(clientEvents);

        for (var i = 0; i < clientEvents.length; i++) {
            var hour = moment(clientEvents[i].start).format("HH");

            if (hour == '00') {
                vm.isBookedFirstPart = true;
                vm.firstPartTime = moment(clientEvents[i].start);
            }
            else if ( hour == '08') {
                vm.isBookedSecondPart = true;
                vm.seconPartTime = moment(clientEvents[i].start);
            }
            else if ( hour == '16') {
                vm.isBookedThirdPart = true;
                vm.thirdPartTime = moment(clientEvents[i].start);
            }
        }

        function save() {
            
            if (!vm.isBookedFirstPart && vm.firstPart) {
                var booking = new BookingData();
                booking.DateFrom = moment(vm.firstPartTime.start).format();
                booking.DateTo = moment(vm.firstPartTime.end).format();
                BookingData.save(booking, function (data) {
                    console.log(data);
                });
            }
            if (!vm.isBookedSecondPart && vm.secondPart) {
                var booking = new BookingData();
                booking.DateFrom = moment(vm.secondPartTime.start).format();
                booking.DateTo = moment(vm.secondPartTime.end).format();
                BookingData.save(booking, function (data) {
                    console.log(data);
                });
            }
            if (!vm.isBookedThirdPart && vm.thirdPart) {
                var booking = new BookingData();
                booking.DateFrom = moment(vm.thirdPartTime.start).format();
                booking.DateTo = moment(vm.thirdPartTime.end).format();
                BookingData.save(booking, function (data) {
                    console.log(data);
                });
            }
            $uibModalInstance.close(vm.firstPart, vm.secondPart, vm.thirdPart);
        }

        function close() {
            $uibModalInstance.dismiss();
        }
    }
})()
(function () {
    'use strict'

    angular
        .module("app.main")
        .controller("ModalController", ModalController);

    ModalController.$inject = ["$uibModalInstance", "clientEvents", "currentDate", "BookingData"];

    function ModalController($uibModalInstance, clientEvents, currentDate, BookingData) {
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
        vm.currentDate = currentDate;
        vm.save = save;
        vm.close = close;
        console.log(moment(currentDate._d).format());
        console.log(currentDate);
        for (var i = 0; i < clientEvents.length; i++) {
            var hour = moment(clientEvents[i].start).format("HH");

            if (hour == '00') {
                vm.isBookedFirstPart = true;
                vm.firstPartTime = clientEvents[i];
            }
            else if ( hour == '08') {
                vm.isBookedSecondPart = true;
                vm.secondPartTime = clientEvents[i];
            }
            else if ( hour == '16') {
                vm.isBookedThirdPart = true;
                vm.thirdPartTime = clientEvents[i];
            }
        }

        console.log(vm.firstPartTime, vm.secondPartTime, vm.thirdPartTime);

        function save() {
            
            if (!vm.isBookedFirstPart && vm.firstPart) {
                var booking = new BookingData();
                booking.DateFrom = moment(vm.currentDate._d).hours(0).format();
                booking.DateTo = moment(vm.currentDate._d).hours(8).format();
                return;
                BookingData.save(booking, function (data) {
                    console.log(data);
                });
            }
            if (!vm.isBookedSecondPart && vm.secondPart) {
                var booking = new BookingData();
                booking.DateFrom = moment(vm.currentDate._d).hours(8).format();
                booking.DateTo = moment(vm.currentDate._d).hours(16).format();
                return;
                BookingData.save(booking, function (data) {
                    console.log(data);
                });
            }
            if (!vm.isBookedThirdPart && vm.thirdPart) {
                var booking = new BookingData();
                booking.DateFrom = moment(vm.currentDate._d).hours(16).format();
                booking.DateTo = moment(vm.currentDate._d).hours(24).format();
                return;
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
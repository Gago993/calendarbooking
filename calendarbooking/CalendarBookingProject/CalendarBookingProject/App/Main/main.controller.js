(function () {
    'use strict'

    angular
        .module("app.main")
        .controller("MainController", MainController);

    MainController.$inject = ["$uibModal"];

    function MainController($uibModal) {
        var vm = this;

        var date = new Date();
        var d = date.getDate();
        var m = date.getMonth();
        var y = date.getFullYear();

        vm.events = [];

        vm.calendar = {
            calendar: {
                height: 550,

                allDayText: '',
                defaultView: 'custom',
                fixedWeekCount: false,
                editable: true,
                header: {
                    left: 'title',
                },
                dayClick: function (date, jsEvent, view) {
                    var clientEvents = $('#calendar').fullCalendar('clientEvents');

                    var modalInstance = $uibModal.open({
                        animation: true,
                        backdrop: 'static',
                        templateUrl: "App/Main/modal.html",
                        controller: "ModalController",
                        controllerAs: "vm",
                        resolve: {
                            clientEvents: function () {
                                return clientEvents;
                            }
                        },
                    });

                    modalInstance.result.then(function (data) {
                        if (data) {
                            console.log(data);
                        }
                    });
                },
                views: {
                    custom: {
                        type: 'month',
                        duration: { weeks: 5 },
                        buttonText: '4 day'
                    }
                },
                events: function (start, end, timezone, callback) {

                    var result = [{ title: "booked", start: "2017-01-13T08:00:00", end: '2017-01-13T:23:59:59' }];
                    
                    callback(result);
                },
                dayRender: function (date, cell) {
                    //$(cell).addClass('fc-state-disabled');
                }
            }
        }

    }
})()
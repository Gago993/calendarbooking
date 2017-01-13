﻿(function () {
    'use strict'

    angular
        .module("app.main")
        .controller("MainController", MainController);

    MainController.$inject = ["$uibModal", "BookingData"];

    function MainController($uibModal, BookingData) {
        var vm = this;

        var date = new Date();
        var d = date.getDate();
        var m = date.getMonth();
        var y = date.getFullYear();

        vm.events = [];

        vm.calendar = {
            calendar: {
                theme:true,
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
                    var currentDate = date;

                    var modalInstance = $uibModal.open({
                        animation: true,
                        backdrop: 'static',
                        templateUrl: "App/Main/modal.html",
                        controller: "ModalController",
                        controllerAs: "vm",
                        resolve: {
                            clientEvents: function () {
                                return clientEvents;
                            },
                            currentDate: function () {
                                return currentDate;
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
                    BookingData.getBookings(function (data) {
                        var response = []
                        console.log(data);
                        for (var i = 0; i < data.length; i++) {
                            var obj = {};
                            obj.title = "booked";
                            obj.start = new Date();
                            obj.end = new Date();
                            obj.UserID = data[i].UserID;
                            response.push(obj);
                        }

                        callback(response);
                        
                    });
                },
                dayRender: function (date, cell) {
                    //$(cell).addClass('fc-state-disabled');
                }
            }
        }

    }
})()
(function() {
    'use strict';

    angular.module("ddd")
        .controller("newAttendeeController", newAttendeeController);

    newAttendeeController.$inject = ['attendeeService', '$location'];

    function newAttendeeController(attendeeService, $location) {
        var vm = this;

        vm.createAttendee = function() {
            attendeeService.create(vm.name)
                .then(function() {
                    $location.path('attendees');
                });
        }
    }
}());
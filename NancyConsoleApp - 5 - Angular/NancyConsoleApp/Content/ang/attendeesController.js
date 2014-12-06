(function() {
    'use strict';

    angular.module("ddd").controller("attendeesController", attendeesController);

    attendeesController.$inject = ['attendeeService'];

    function attendeesController(attendeeService) {
        var vm = this;

        attendeeService.getAll()
            .then(function(response) {
                vm.attendees = response.attendees;
            });
    }
}());
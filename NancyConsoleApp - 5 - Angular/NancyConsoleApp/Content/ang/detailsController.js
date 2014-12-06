(function() {
    'use strict';

    angular.module("ddd")
        .controller("detailsController", detailsController);

    detailsController.$inject = ['attendeeService', '$routeParams', '$location'];
    
    function detailsController(attendeeService, $routeParams, $location) {
        var vm = this;
        vm.id = $routeParams.id;

        vm.updateAttendee = updateAttendee;

        attendeeService.getById(vm.id)
            .then(function(attendee) {
                vm.attendee = attendee;
            });

        function updateAttendee() {
            attendeeService.update(vm.attendee)
                .then(function() {
                    $location.path("attendees");
                });
        }
    }
}());
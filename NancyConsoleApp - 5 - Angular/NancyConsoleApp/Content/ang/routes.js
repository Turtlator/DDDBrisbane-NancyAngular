(function() {
    'use strict';

    angular.module("ddd").config(['$routeProvider', configureRoutes]);

    function configureRoutes($routeProvider) {
        $routeProvider
        .when("/attendees", {
            templateUrl: "/content/ang/views/attendees.html"
        })
        .when("/attendees/create", {
            templateUrl: "/content/ang/views/new.html"
        })
        .when("/attendees/:id", {
            templateUrl: "/content/ang/views/details.html"
        })
        .otherwise({
            redirectTo: "/attendees"
        });
    }
}());
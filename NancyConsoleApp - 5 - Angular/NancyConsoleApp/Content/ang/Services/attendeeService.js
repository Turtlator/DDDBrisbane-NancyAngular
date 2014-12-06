(function() {
    'use strict';

    angular.module("ddd")
        .service("attendeeService", attendeeService);

    attendeeService.$inject = ['$q', '$http'];

    function attendeeService($q, $http) {
        return {
            getAll: getAll,
            getById: getById,
            create: create,
            update: update
        };

        function get(url) {
            var deferred = $q.defer();

            $http.get(url)
                .success(function(response) {
                    deferred.resolve(response);
                })
                .error(function(response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        }

        function post(url, data) {
            var deferred = $q.defer();

            $http.post(url, data)
                .success(function (response) {
                    deferred.resolve(response);
                })
                .error(function (response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        }

        function getAll() {
            var url = "/attendees";

            return get(url);
        }

        function getById(id) {
            var url = "/attendees/" + id;

            return get(url);
        }

        function create(name) {
            var url = "/attendee/new";
            var data = {
                name: name
            };

            return post(url, data);
        }

        function update(attendee) {
            var url = "/attendees";

            return post(url, attendee);
        }
    }
}());
app.service("CurrentUserService", [
    "$http", function ($http) {

        this.getCurrentUserMinInfo = function () {
            return $http.get("/api/CurrentUserWebApi");
        }

        this.getEvents = function() {
            return $http.get("/api/CurrentUserWebApi/GetEvents");
        }
    }
]);
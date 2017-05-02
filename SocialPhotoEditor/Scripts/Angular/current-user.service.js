app.service("CurrentUserService", [
    "$http", function ($http) {

        this.getCurrentUserMinInfo = function () {
            return $http({ method: "GET", url: "/api/CurrentUserWebApi" });
        }
    }
]);
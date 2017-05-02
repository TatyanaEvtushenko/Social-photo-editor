app.service("UsersService", [
    "$http", function ($http) {

        this.getUserList = function() {
            return $http({ method: "GET", url: "/api/UserWebApi" });
        }
    }
]);
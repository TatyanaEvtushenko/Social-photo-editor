app.service("UsersService", [
    "$http", function ($http) {

        this.getUserList = function() {
            return $http({ method: "GET", url: "/api/UserWebApi" });
        }

        this.getUserPage = function(userName) {
            return $http({ method: "POST", url: "/api/UserWebApi/" + userName });
        }
    }
]);
app.service("UserListService", [
    "$http", function ($http) {

        this.getUserList = function() {
            return $http({ method: "GET", url: "/api/UserWebApi" });
        }
    }
]);
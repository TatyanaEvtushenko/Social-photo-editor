app.service("UsersService", [
    "$http", function ($http) {

        this.getUsers = function() {
            return $http({
                method: "GET",
                url: "/api/UserWebApi"
            });
        }

        this.getUserInfo = function() {
            
        }
    }
]);
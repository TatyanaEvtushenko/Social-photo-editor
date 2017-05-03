app.service("UsersService", [
    "$http", function ($http) {

        this.getUserList = function() {
            return $http({ method: "GET", url: "/api/UserWebApi" });
        }

        this.getUserPage = function () {
            var url = window.location.search;
            var params = url.substring(url.indexOf("?") + 1).split("=");
            return $http({ method: "GET", url: "/api/UserWebApi/" + params[1] });
        }
    }
]);
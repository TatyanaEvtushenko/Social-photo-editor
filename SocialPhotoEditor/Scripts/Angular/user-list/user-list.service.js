app.service("UserListService", [
    "$http", function ($http) {

        this.getCountries = function () {
            return $http({ method: "GET", url: "/api/CountryWebApi" });
        }




        this.getUserList = function() {
            return $http({ method: "GET", url: "/api/UserWebApi" });
        }

        this.subscribe = function (userName) {
            return $http({ method: "PUT", url: "/api/RelationshipWebApi/", params: { 'userName': userName } });
        }

        this.unsubscribe = function (id) {
            return $http({ method: "DELETE", url: "/api/RelationshipWebApi/", params: { 'id': id } });
        }
    }
]);
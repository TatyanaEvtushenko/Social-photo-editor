app.service("UserListService", [
    "$http", function ($http) {

        this.getUserList = function() {
            return $http({ method: "GET", url: "/api/UserWebApi" });
        }

        this.subscribe = function (userName) {
            return $http({ method: "PUT", url: "/api/RelationshipWebApi/", params: { 'userName': userName } });
        }

        this.unsubscribe = function (userName) {
            return $http({ method: "DELETE", url: "/api/RelationshipWebApi/", params: { 'userName': userName } });
        }
    }
]);
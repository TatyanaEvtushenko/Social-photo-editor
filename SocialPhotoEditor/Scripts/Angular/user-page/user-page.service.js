app.service("UserPageService", [
    "$http", function ($http) {

        this.getUserPage = function (userName) {
            return $http({ method: "POST", url: "/api/UserWebApi/", params: { 'userName': userName } });
        }

        this.getFolder = function (folderId) {
            return $http({ method: "POST", url: "/api/FolderWebApi/", params: { 'folderId': folderId } });
        }

        this.subscribe = function (userName) {
            return $http({ method: "PUT", url: "/api/RelationshipWebApi/", params: { 'userName': userName } });
        }

        this.unsubscribe = function (userName) {
            return $http({ method: "DELETE", url: "/api/RelationshipWebApi/", params: { 'userName': userName } });
        }

        this.getSubscribers = function (userName) {
            return $http({ method: "POST", url: "/api/RelationshipWebApi/subscribers", params: { 'userName': userName } });
        }

        this.getSubscriptions = function (userName) {
            return $http({ method: "POST", url: "api/RelationshipWebApi/subscriptions", params: { 'userName': userName } });
        }
    }
]);
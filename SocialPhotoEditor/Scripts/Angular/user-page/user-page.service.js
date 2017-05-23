app.service("UserPageService", [
    "$http", function ($http) {

        this.getUserPage = function (userName) {
            return $http({ method: "POST", url: "/api/UserWebApi/", params: { 'userName': userName } });
        }

        this.getFolder = function (folderId) {
            return $http({ method: "POST", url: "/api/FolderWebApi/", params: { 'folderId': folderId } });
        }

        this.getMoreImages = function (pageNumber, folderId) {
            var response = {
                "page": pageNumber,
                "folderId": folderId
            }
            return $http.post("/api/FolderWebApi/", response);
        }



        this.subscribe = function (userName) {
            return $http({ method: "PUT", url: "/api/RelationshipWebApi/", params: { 'userName': userName } });
        }

        this.unsubscribe = function (id) {
            return $http({ method: "DELETE", url: "/api/RelationshipWebApi/", params: { 'id': id } });
        }

        this.getSubscribers = function (userName) {
            return $http({ method: "POST", url: "/api/RelationshipWebApi/Subscribers/", params: { 'userName': userName } });
        }

        this.getSubscriptions = function (userName) {
            return $http({ method: "POST", url: "api/RelationshipWebApi/Subscriptions/", params: { 'userName': userName } });
        }
    }
]);
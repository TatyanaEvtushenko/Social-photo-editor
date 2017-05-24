app.service("UserPageService", [
    "$http", function ($http) {

        this.getUserPage = function (userName) {
            return $http({ method: "POST", url: "/api/UserWebApi/", params: { 'userName': userName } });
        }

        this.getFolder = function (folderId) {
            return $http({ method: "POST", url: "/api/FolderWebApi/", params: { 'folderId': folderId } });
        }

        this.getMoreImagesFromFolder = function (pageNumber, folderId) {
            var response = {
                "page": pageNumber,
                "folderId": folderId
            };
            return $http.post("/api/FolderWebApi/", response);
        }

        this.getMoreUserImages = function (pageNumber, userName) {
            var response = {
                "page": pageNumber,
                "user": userName
            };
            return $http.post("/api/FolderWebApi/MoreUserImages/", response);
        }
        
        this.deleteFolder = function (folderId) {
            return $http({ method: "DELETE", url: "/api/FolderWebApi/", params: { 'folderId': folderId } });
        }

        this.getSubscribers = function (userName) {
            return $http({ method: "POST", url: "/api/RelationshipWebApi/Subscribers/", params: { 'userName': userName } });
        }

        this.getSubscriptions = function (userName) {
            return $http({ method: "POST", url: "/api/RelationshipWebApi/Subscriptions/", params: { 'userName': userName } });
        }

        this.subscribe = function (userName) {
            return $http({ method: "PUT", url: "/api/RelationshipWebApi/", params: { 'userName': userName } });
        }

        this.unsubscribe = function (id) {
            return $http({ method: "DELETE", url: "/api/RelationshipWebApi/", params: { 'id': id } });
        }
    }
]);
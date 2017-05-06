app.service("UserPageService", [
    "$http", function ($http) {

        this.getUserPage = function (userName) {
            return $http({ method: "POST", url: "/api/UserWebApi/", params: { 'userName': userName } });
        }

        this.getFolder = function (folderId) {
            return $http({ method: "POST", url: "/api/ImageWebApi/", params: { 'folderId': folderId } });
        }

        this.getLike = function (imageFileName) {
            return $http({ method: "POST", url: "/api/LikeWebApi/", params: { 'imageFileName': imageFileName } });
        }

        this.changeLike = function (imageFileName) {
            return $http({ method: "PUT", url: "/api/LikeWebApi/", params: { 'imageFileName': imageFileName } });
        }

        this.getComments = function (imageFileName) {
            return $http({ method: "POST", url: "/api/CommentWebApi/", params: { 'imageFileName': imageFileName } });
        }

        this.addComment = function (text, imageId) {
            return $http({ method: "POST", url: "/api/CommentWebApi/", params: { 'text': text, 'imageId': imageId } });
        }
    }
]);
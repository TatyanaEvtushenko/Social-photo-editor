app.service("ImageService", [
    "$http", function ($http) {

        this.getImage = function (imageFileName) {
            return $http({ method: "POST", url: "/api/ImageWebApi/", params: { 'imageFileName': imageFileName } });
        }

        this.addLike = function (imageFileName) {
            return $http({ method: "PUT", url: "/api/LikeWebApi/", params: { 'imageFileName': imageFileName } });
        }

        this.deleteLike = function (id) {
            return $http({ method: "DELETE", url: "/api/LikeWebApi/", params: { 'id': id } });
        }

        this.addComment = function (text, imageId, recipientUserName) {
            var response = {
                text: text,
                image: imageId,
                recipient: recipientUserName
            };
            return $http.put("/api/CommentWebApi/", response);
        }

        this.deleteComment = function (commentId) {
            return $http({ method: "DELETE", url: "/api/CommentWebApi/", params: { 'commentId': commentId } });
        }

        this.changeAvatar = function (imageFileName) {
            return $http({ method: "PUT", url: "/api/UserWebApi/", params: { 'imageFileName': imageFileName } });
        }

        this.deleteImage = function (imageFileName) {
            return $http({ method: "DELETE", url: "/api/ImageWebApi/", params: { 'imageFileName': imageFileName } });
        }
    }
]);
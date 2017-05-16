app.service("ImageService", [
    "$http", function ($http) {

        this.getImage = function (imageFileName) {
            return $http({ method: "POST", url: "/api/ImageWebApi/", params: { 'imageFileName': imageFileName } });
        }

        this.addLike = function (imageFileName) {
            return $http({ method: "PUT", url: "/api/LikeWebApi/", params: { 'imageFileName': imageFileName } });
        }

        this.deleteLike = function (imageFileName) {
            return $http({ method: "DELETE", url: "/api/LikeWebApi/", params: { 'imageFileName': imageFileName } });
        }

        this.addComment = function (text, imageId, time) {
            return $http({ method: "PUT", url: "/api/CommentWebApi/", params: { 'text': text, 'imageId': imageId, 'time': time } });
        }

        this.deleteComment = function (commentatorUserName, imageId, time) {
            return $http({ method: "DELETE", url: "/api/CommentWebApi/", params: { 'commentatorUserName': commentatorUserName, 'imageId': imageId, 'time': time } });
        }

        this.changeAvatar = function (imageFileName) {
            return $http({ method: "PUT", url: "/api/AvatarWebApi/", params: { 'imageFileName': imageFileName } });
        }
    }
]);
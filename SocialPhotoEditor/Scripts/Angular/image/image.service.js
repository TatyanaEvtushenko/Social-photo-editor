app.service("ImageService", [
    "$http", function ($http) {

        this.getComments = function (imageFileName) {
            return $http({ method: "POST", url: "/api/CommentWebApi/", params: { 'imageFileName': imageFileName } });
        }

        this.getLike = function (imageFileName) {
            return $http({ method: "POST", url: "/api/LikeWebApi/", params: { 'imageFileName': imageFileName } });
        }

        this.changeLike = function (imageFileName) {
            return $http({ method: "PUT", url: "/api/LikeWebApi/", params: { 'imageFileName': imageFileName } });
        }

        this.addComment = function (text, imageId) {
            return $http({ method: "PUT", url: "/api/CommentWebApi/", params: { 'text': text, 'imageId': imageId } });
        }

        this.deleteComment = function (commentatorUserName, imageId, time) {
            return $http({ method: "DELETE", url: "/api/CommentWebApi/", params: { 'commentatorUserName': commentatorUserName, 'imageId': imageId, 'time': time } });
        }

        this.changeAvatar = function (imageFileName) {
            return $http({ method: "PUT", url: "/api/AvatarWebApi/", params: { 'imageFileName': imageFileName } });
        }
    }
]);
app.controller("ImageController", [
    "$scope", "ImageService", function ($scope, ImageService) {

        function getComments(imageId) {
            ImageService.getComments(imageId).then(function (http) {
                $scope.comments = http.data;
            }, function (error) {
                console.log("Error from server! (comments)");
            });
        }

        function getLike(imageId) {
            ImageService.getLike(imageId).then(function (http) {
                $scope.like = http.data;
            }, function (error) {
                console.log("Error from server! (likes)");
            });
        }

        function addComment(text, imageId) {
            ImageService.addComment(text, imageId).then(function (http) {
                $scope.comments = http.data;
            }, function (error) {
                console.log("Error from server! (add comment)");
            });
        }

        function deleteComment(commentatorUserName, imageId, time) {
            ImageService.deleteComment(commentatorUserName, imageId, time).then(function (http) {
                $scope.comments = http.data;
            }, function (error) {
                console.log("Error from server! (delete comment)");
            });
        }

        function changeLike(imageId) {
            ImageService.changeLike(imageId).then(function (http) {
            }, function (error) {
                console.log("Error from server! (change like)");
            });
        }

        function changeAvatar(imageId) {
            ImageService.changeAvatar(imageId).then(function (http) {
            }, function (error) {
                console.log("Error from server! (avatar)");
            });
        }

        $('#imageModal').on('show.bs.modal', function (e) {
            getLike($scope.image.FileName);
            getComments($scope.image.FileName);
        });

        $scope.changeLike = function (imageId) {
            changeLike(imageId);
            $scope.like.IsLiked = !$scope.like.IsLiked;
            if ($scope.like.IsLiked)
                $scope.like.Count++;
            else
                $scope.like.Count--;
        }

        $scope.addComment = function () {
            addComment($scope.commentText.trim(), $scope.image.FileName);
            $scope.commentText = "";
        }

        $scope.deleteComment = function(commentatorUserName, time) {
            deleteComment(commentatorUserName, $scope.image.FileName, time);
        }
        
        $scope.changeAvatar = function(imageId) {
            changeAvatar(imageId);
            window.location.reload();
        }
    }
]);
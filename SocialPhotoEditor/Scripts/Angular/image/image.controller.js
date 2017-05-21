app.controller("ImageController", [
    "$scope", "ImageService", function ($scope, ImageService) {

        $("#imageModal").on("show.bs.modal", function(e) {
            ImageService.getImage($scope.imageId).then(function(http) {
                $scope.image = http.data;
                if ($scope.image != null && $scope.image.length !== 0) {
                    $scope.image.Comments.sort(function (a, b) {
                        if (a.Time < b.Time) {
                            return 1;
                        }
                        if (a.Time > b.Time) {
                            return -1;
                        }
                        return 0;
                    });
                }
            }, function(error) {
                console.log("Error from server! (image)");
            });
        });
        
        $scope.changeAvatar = function () {
            $.cloudinary.image('sample.jpg', { width: 100, height: 150, crop: 'fill' });
            alert("fghj");
            //ImageService.changeAvatar($scope.image.FileName).then(function (http) {
            //}, function (error) {
            //    console.log("Error from server! (avatar)");
            //});
            //window.location.reload();
        }

        $scope.addLike = function () {
            ImageService.addLike($scope.image.FileName).then(function (http) {
                if (http.data != null) {
                    $scope.image.LikeId = http.data;
                    $scope.image.LikesCount++;
                }
            }, function (error) {
                console.log("Error from server! (add like)");
            });
        }

        $scope.deleteLike = function () {
            ImageService.deleteLike($scope.image.LikeId).then(function (http) {
                if (http.data) {
                    $scope.image.LikeId = null;
                    $scope.image.LikesCount--;
                }
            }, function (error) {
                console.log("Error from server! (delete like)");
            });
        }

        $scope.answer = function (userName) {
            $scope.answerUserName = userName;
            $scope.commentText = '@' + userName + ', ';
        }

        $scope.addComment = function () {
            var text = $scope.commentText.trim();
            if (text.indexOf('@' + $scope.answerUserName + ', ') === 0) {
                text = text.substring(('@' + $scope.answerUserName + ', ').length);
            } else {
                $scope.answerUserName = null;
            }
            ImageService.addComment(text, $scope.image.FileName, $scope.answerUserName).then(function (http) {
                if (http.data != null) {
                    var comment = {
                        Text: text,
                        Time: new Date(Date.now()),
                        RecipientUserName: $scope.answerUserName,
                        OwnerUserName: $scope.currentUser.User.UserName,
                        Id: http.data
                    };
                    $scope.image.Comments[$scope.image.Comments.length] = comment;
                    $scope.commentText = "";
                }
            }, function (error) {
                console.log("Error from server! (add comment)");
            });
        }

        $scope.deleteComment = function (index) {
            var id = $scope.image.Comments[index].Id;
            ImageService.deleteComment(id).then(function (http) {
                if (http.data) {
                    $scope.image.Comments.splice(index, 1);
                }
            }, function (error) {
                console.log("Error from server! (delete comment)");
            });
        }
    }
]);
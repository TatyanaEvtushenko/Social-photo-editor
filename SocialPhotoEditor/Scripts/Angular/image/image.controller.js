app.controller("ImageController", [
    "$scope", "ImageService", function ($scope, ImageService) {

        $('#imageModal').on('show.bs.modal', function(e) {
            ImageService.getImage($scope.imageId).then(function(http) {
                $scope.image = http.data;
            }, function(error) {
                console.log("Error from server! (image)");
            });
        });

        $scope.getDate = function(time) {
            var date = new Date(time);
            var dateNow = new Date(Date.now());
            var count = dateNow.getFullYear() - date.getFullYear();
            if (count >= 1)
                return count.toString() + " г.";
            count = dateNow.getMonth() - date.getMonth();
            if (count >= 1)
                return count.toString() + " мес.";
            count = dateNow.getDate() - date.getDate();
            if (count >= 1)
                return count.toString() + " дн.";
            count = dateNow.getHours() - date.getHours();
            if (count >= 1)
                return count.toString() + " ч.";
            count = dateNow.getMinutes() - date.getMinutes();
            if (count >= 1)
                return count.toString() + " мин.";
            count = dateNow.getSeconds() - date.getSeconds();
            return count.toString() + " сек.";
        }

        $scope.answer = function (userName) {
            $scope.answerUserName = userName;
            $scope.commentText = '@' + userName + ', ';
        }

        $scope.addLike = function () {
            ImageService.addLike($scope.image.FileName).then(function (http) {
                $scope.image.IsLiked = true;
                $scope.image.LikesCount++;
            }, function (error) {
                console.log("Error from server! (add like)");
            });
        }

        $scope.deleteLike = function () {
            ImageService.deleteLike($scope.image.FileName).then(function (http) {
                $scope.image.IsLiked = false;
                $scope.image.LikesCount--;
            }, function (error) {
                console.log("Error from server! (delete like)");
            });
        }

        $scope.addComment = function () {
            var text = $scope.commentText.trim();
            if (text.indexOf('@' + $scope.answerUserName + ', ') === 0) {
                text = text.substring(('@' + $scope.answerUserName + ', ').length);
            } else {
                $scope.answerUserName = null;
            }
            var time = new Date(Date.now());
            ImageService.addComment(text, $scope.image.FileName, time, $scope.answerUserName).then(function (http) {
                var comment = {};
                comment.Text = text;
                comment.Time = time;
                comment.RecipientUserName = $scope.answerUserName;
                comment.OwnerUserName = $scope.currentUserName;
                $scope.image.Comments[$scope.image.Comments.length] = comment;
                $scope.commentText = "";
            }, function (error) {
                console.log("Error from server! (add comment)");
            });
        }

        $scope.deleteComment = function (index) {
            var commentatorUserName = $scope.image.Comments[index].OwnerUserName;
            var time = $scope.image.Comments[index].Time;
            ImageService.deleteComment(commentatorUserName, $scope.image.FileName, time).then(function (http) {
                $scope.image.Comments.splice(index, 1);
            }, function (error) {
                console.log("Error from server! (delete comment)");
            });
        }
        
        $scope.changeAvatar = function () {
            ImageService.changeAvatar($scope.image.FileName).then(function (http) {
            }, function (error) {
                console.log("Error from server! (avatar)");
            });
            window.location.reload();
        }
    }
]);
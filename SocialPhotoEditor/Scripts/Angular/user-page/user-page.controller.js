app.controller("UserPageController", [
    "$scope", "UserPageService", function ($scope, UserPageService) {

        function getParamFromUrl(paramName) {
            var url = window.location.search;
            var params = url.substring(url.indexOf("?") + 1).split("&");
            if (params === "")
                return null;
            for (var i in params) {
                var param = params[i].split("=");
                if (param[0] === paramName)
                    return param[1];
            }
            return null;
        }

        function getUserPage(userName) {
            UserPageService.getUserPage(userName).then(function (http) {
                $scope.userPage = http.data;
            }, function (error) {
                console.log("Error from server! (user page)");
            });
        }

        function getFolder(folderId) {
            UserPageService.getFolder(folderId).then(function (http) {
                $scope.folder = http.data;
            }, function (error) {
                console.log("Error from server! (image lists)");
            });
        }

        function getComments(imageId) {
            UserPageService.getComments(imageId).then(function (http) {
                $scope.comments = http.data;
            }, function (error) {
                console.log("Error from server! (comments)");
            });
        }

        function addComment(text, imageId) {
            UserPageService.addComment(text, imageId).then(function (http) {
            }, function (error) {
                console.log("Error from server! (comments)");
            });
        }

        function changeLike(imageId) {
            UserPageService.changeLike(imageId).then(function (http) {
            }, function (error) {
                console.log("Error from server! (change like)");
            });
        }

        function getLike(imageId) {
            UserPageService.getLike(imageId).then(function (http) {
                $scope.like = http.data;
            }, function (error) {
                console.log("Error from server! (comments)");
            });
        }

        var userName = getParamFromUrl("userName");
        getUserPage(userName);
        getFolder(userName);

        $scope.getImage = function (image) {
            $scope.image = {};
            $scope.image.FileName = image.FileName;
            $scope.image.CreatingTime = image.CreatingTime;
            $scope.owner = {};
            $scope.owner.UserName = userName;
            $scope.owner.AvatarFileName = $scope.userPage.AvatarFileName;
            getLike(image.FileName);
            getComments(image.FileName);
        }

        $scope.getFolder = function (folderId) {
            getFolder(folderId);
        }

        $scope.changeLike = function(imageId) {
            changeLike(imageId);
            $scope.like.IsLiked = !$scope.like.IsLiked;
            if ($scope.like.IsLiked)
                $scope.like.Count++;
            else
                $scope.like.Count--;
        }

        $scope.changeComment = function() {
            if ($scope.commentText.indexOf("\n") > 0) {
                addComment($scope.commentText.trim(), $scope.image.FileName);
                $scope.commentText = "";
            }
        }
    }
]);
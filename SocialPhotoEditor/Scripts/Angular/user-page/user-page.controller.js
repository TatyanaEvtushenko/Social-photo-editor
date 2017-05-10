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
        }

        $scope.getFolder = function (folderId) {
            getFolder(folderId);
        }
    }
]);
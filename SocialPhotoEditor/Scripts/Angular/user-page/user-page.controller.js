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

        function getFolder(folderId) {
            UserPageService.getFolder(folderId).then(function (http) {
                $scope.folder = http.data;
            }, function (error) {
                console.log("Error from server! (image lists)");
            });
        }


        var userName = getParamFromUrl("userName");

        UserPageService.getUserPage(userName).then(function (http) {
            $scope.userPage = http.data;
        }, function (error) {
            console.log("Error from server! (user page)");
        });
        getFolder(userName);

        $scope.getImage = function (fileName) {
            $scope.imageId = fileName;
        }

        $scope.getFolder = function (folderId) {
            getFolder(folderId);
        }

        $scope.subscribe = function () {
            UserPageService.subscribe(userName).then(function (http) {
                $scope.userPage.IsSubscriber = true;
                $scope.userPage.SubscribersCount++;
            }, function (error) {
                console.log("Error from server! (subscribe)");
            });
        }

        $scope.unsubscribe = function () {
            UserPageService.unsubscribe(userName).then(function (http) {
                $scope.userPage.IsSubscriber = false;
                $scope.userPage.SubscribersCount--;
            }, function (error) {
                console.log("Error from server! (unsubscribe)");
            });
        }

        $scope.getSubscribers = function () {
            UserPageService.getSubscribers(userName).then(function (http) {
                $scope.users = http.data;
            }, function (error) {
                console.log("Error from server! (subscribers)");
            });
        }

        $scope.getSubscriptions = function () {
            UserPageService.getSubscriptions(userName).then(function (http) {
                $scope.users = http.data;
            }, function (error) {
                console.log("Error from server! (subscriptions)");
            });
        }
    }
]);
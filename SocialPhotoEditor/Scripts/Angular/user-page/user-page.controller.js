app.controller("UserPageController", [
    "$scope", "UserPageService", function ($scope, UserPageService) {

        var userName = $scope.getParamFromUrl("userName");

        UserPageService.getUserPage(userName).then(function (http) {
            $scope.userPage = http.data;
            $scope.getFolder(userName);
        }, function (error) {
            console.log("Error from server! (user page)");
        });

        $scope.getImage = function (fileName) {
            $scope.imageId = fileName;
        }

        $scope.getFolder = function (folderId) {

            UserPageService.getFolder(folderId).then(function (http) {
                $scope.folder = http.data;
            }, function (error) {
                console.log("Error from server! (image lists)");
            });
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
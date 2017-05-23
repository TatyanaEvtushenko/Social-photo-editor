app.controller("UserPageController", [
    "$scope", "UserPageService", function ($scope, UserPageService) {

        var userName = $scope.getParamFromUrl("userName");
        var pageCount = 0;

        UserPageService.getUserPage(userName).then(function (http) {
            $scope.userPage = http.data;
            $scope.getFolder(userName);
        }, function (error) {
            console.log("Error from server! (user page)");
        });

        $scope.getImage = function (fileName) {
            $scope.imageId = fileName;
        }

        $scope.getMoreImages = function () {
            var oldLength = $scope.folder.Images.length;
            UserPageService.getMoreImages(pageCount + 1, $scope.folder.Id).then(function (http) {
                if (http.data != null) {
                    $scope.folder.Images = $scope.folder.Images.concat(http.data);
                    pageCount++;
                    if ($scope.folder.Images.length === oldLength) {
                        $("#moreImagesButton").hide();
                    }
                }
            }, function (error) {
                console.log("Error from server! (folder)");
            });
        }

        $scope.getFolder = function (folderId) {
            UserPageService.getFolder(folderId).then(function (http) {
                if (http.data != null) {
                    $scope.folder = http.data;
                    pageCount = 0;
                    $("#moreImagesButton").show();

                    console.log($scope.folder);
                    $("li").removeClass("active");
                    console.log("#" + folderId);
                    $("#" + folderId).addClass("active");
                }
            }, function (error) {
                console.log("Error from server! (folder)");
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
app.controller("UserMinListController", [
    "$scope", "UserMinListService", function ($scope, UserMinListService) {

        $scope.subscribe = function (index) {
            var userName = $scope.userLists[index].UserName;
            if (userName === $scope.currentUser.User.UserName) return;
            UserMinListService.subscribe(userName).then(function (http) {
                $scope.userLists[index].SubscriptionId = http.data;
            }, function (error) {
                console.log("Error from server! (subscribe)");
            });
        }

        $scope.unsubscribe = function (index) {
            var user = $scope.userLists[index];
            if (user.UserName === $scope.currentUser.User.UserName) return;
            UserMinListService.unsubscribe(user.SubscriptionId).then(function (http) {
                if (http.data) {
                    $scope.userLists[index].SubscriptionId = null;
                    if ($scope.userPage.UserName === $scope.currentUser.User.UserName) {
                        $scope.userLists.splice(index, 1);
                        $scope.userPage.SubscriptionsCount--;
                    }
                }
            }, function (error) {
                console.log("Error from server! (unsubscribe)");
            });
        }
    }
]);
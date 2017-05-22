app.controller("UserMinListController", [
    "$scope", "UserMinListService", function ($scope, UserMinListService) {

        function subscribe(userName) {
            UserMinListService.subscribe(userName).then(function (http) {
            }, function (error) {
                console.log("Error from server! (subscribe)");
            });
        }

        function unsubscribe(userName) {
            UserMinListService.unsubscribe(userName).then(function (http) {
            }, function (error) {
                console.log("Error from server! (unsubscribe)");
            });
        }

        $scope.subscribe = function (userName) {
            subscribe(userName);
            $scope.user.IsSubscriber = true;
        }

        $scope.unsubscribe = function (userName) {
            unsubscribe(userName);
            $scope.user.IsSubscriber = false;
        }
    }
]);
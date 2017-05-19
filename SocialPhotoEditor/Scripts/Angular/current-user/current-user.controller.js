app.controller("CurrentUserController", [
    "$scope", "CurrentUserService", function ($scope, CurrentUserService) {

        CurrentUserService.getCurrentUserMinInfo().then(function (http) {
            $scope.currentUser = http.data;
        });
    }
]);
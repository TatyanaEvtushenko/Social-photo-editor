app.controller("CurrentUserController", [
    "$scope", "CurrentUserService", function ($scope, CurrentUserService) {

        CurrentUserService.getCurrentUserMinInfo().then(function (http) {
            $scope.currentUserName = http.data.Name;
            $scope.currentUserAvatar = http.data.AvatarFileName;
        });
    }
]);
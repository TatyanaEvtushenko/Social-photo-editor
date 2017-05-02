app.controller("UsersController", [
    "$scope", "UsersService", function ($scope, UsersService) {
        $scope.usersData = [];
        $scope.users = [];
        $scope.minAge = 0;
        $scope.maxAge = 99;
        $scope.searchString = "";

        UsersService.getUserList().then(function (http) {
            $scope.users = $scope.usersData = http.data;
            $scope.filterUsers();
        }, function (error) {
            console.log("Error with Server!");
        });

        $scope.filterUsers = function () {
            $scope.users = $scope.usersData.filter(function (user) {
                return user.UserName.indexOf($scope.searchString) > -1 && user.Age >= $scope.minAge && user.Age <= $scope.maxAge;
            });
        }

        $scope.changeFilterAge = function(value) {
            $scope.minAge = $scope.maxAge = value;
            $scope.filterUsers();
        }

        $scope.changeFilterCountry = function(value) {
            
        }

        $scope.changeFilterCity = function(value) {
            
        }

        $scope.subscribe = function() {
            
        }

        $scope.unsubscribe = function() {
            
        }
    }
]);
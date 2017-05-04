app.controller("UsersController", [
    "$scope", "UsersService", function ($scope, UsersService) {

        $scope.userLists = [];
        $scope.filteredUserLists = [];
        $scope.minAge = 0;
        $scope.maxAge = 99;
        $scope.searchString = "";

        $scope.userPage = {};
        

        function getUserNameFromUrl() {
            var url = window.location.search;
            var params = url.substring(url.indexOf("?") + 1).split("=");
            return params[1];
        }

        UsersService.getUserPage(getUserNameFromUrl()).then(function (http) {
            $scope.userPage = http.data;
        }, function (error) {
            console.log("Error from server! (user page)");
        });

        UsersService.getUserList().then(function (http) {
            $scope.filteredUserLists = $scope.userLists = http.data;
        }, function(error) {
            console.log("Error from server! (user lists)");
        });

        $scope.filterUserLists = function () {
            $scope.filteredUserLists = $scope.userLists.filter(function (user) {
                return (user.UserName.indexOf($scope.searchString) > -1 || user.Name.indexOf($scope.searchString) > -1) && user.Age >= $scope.minAge && user.Age <= $scope.maxAge;
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
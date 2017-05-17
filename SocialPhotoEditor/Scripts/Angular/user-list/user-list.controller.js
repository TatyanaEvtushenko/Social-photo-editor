app.controller("UserListController", [
    "$scope", "UserListService", function ($scope, UserListService) {

        UserListService.getUserList().then(function (http) {
            $scope.filteredUserLists = $scope.userLists = http.data;
        }, function (error) {
            console.log("Error from server! (user lists)");
        });

        $scope.minAge = 0;
        $scope.maxAge = 99;
        $scope.searchString = "";

        $scope.getAge = function (birthday) {
            if (birthday == null)
                return null;
            var date = new Date(birthday);
            var dateNow = new Date(Date.now());
            var yearSubtract = dateNow.getFullYear() - date.getFullYear();
            if ((dateNow.getMonth() < date.getMonth()) || (dateNow.getMonth() === date.getMonth() && dateNow.getDate() < date.getDate()))
                return yearSubtract - 1;
            return yearSubtract;
        }

        $scope.getImage = function (fileName) {
            $scope.imageId = fileName;
        }

        $scope.subscribe = function (index) {
            UserListService.subscribe($scope.filteredUserLists[index].UserName).then(function (http) {
                $scope.filteredUserLists[index].IsSubscriber = true;
            }, function (error) {
                console.log("Error from server! (subscribe)");
            });
        }

        $scope.unsubscribe = function (index) {
            UserListService.unsubscribe($scope.filteredUserLists[index].UserName).then(function (http) {
                $scope.filteredUserLists[index].IsSubscriber = false;
            }, function (error) {
                console.log("Error from server! (unsubscribe)");
            });
        }

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
    }
]);
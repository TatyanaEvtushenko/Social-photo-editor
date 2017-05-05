app.controller("UsersController", [
    "$scope", "UsersService", function ($scope, UsersService) {
        
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

        function getUserLists() {
            UsersService.getUserList().then(function (http) {
                $scope.filteredUserLists = $scope.userLists = http.data;
            }, function (error) {
                console.log("Error from server! (user lists)");
            });
        }

        function getUserPage(userName) {
            UsersService.getUserPage(userName).then(function (http) {
                $scope.userPage = http.data;
            }, function (error) {
                console.log("Error from server! (user page)");
            });
        }

        function getFolder(folderId) {
            UsersService.getFolder(folderId).then(function (http) {
                $scope.folder = http.data;
            }, function (error) {
                console.log("Error from server! (image lists)");
            });
        }

        var userName = getParamFromUrl("userName");
        if (userName == null) {
            getUserLists();
            $scope.minAge = 0;
            $scope.maxAge = 99;
            $scope.searchString = "";
        }
        else {
            getUserPage(userName);
            getFolder(userName);
        }


        $scope.getFolder = function (folderId) {
            getFolder(folderId);
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

        $scope.subscribe = function() {
            
        }

        $scope.unsubscribe = function() {
            
        }
    }
]);
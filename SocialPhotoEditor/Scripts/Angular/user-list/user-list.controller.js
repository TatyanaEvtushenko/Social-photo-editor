app.controller("UserListController", [
    "$scope", "UserListService", function ($scope, UserListService) {

        $scope.searchString = $scope.getParamFromUrl("searchString");
        var cityName = null;
        var countryName = null;

        UserListService.getCountries().then(function (http) {
            $scope.countries = http.data;
        }, function (error) {
            console.log("Error from server! (countries)");
        });

        $scope.selectCountry = function (country) {
            alert(country);
            cityName = null;
            $("#citiesSelect [value='default']").attr("selected", "selected");

            if (country === null) {
                countryName = null;
                $scope.cities = null;
                $("#citiesSelect").attr("disabled", "disabled");
            } else {
                country = country.Name;
                $scope.cities = country.Cities;
                $("#citiesSelect").attr("disabled", "");
            }
        }

        $scope.selectCity = function (country) {
            if (country === null) {
                $scope.country = null;
                $scope.cities = null;
            } else {
                $scope.country = country.Name;
                $scope.cities = country.Cities;
            }
        }





        UserListService.getUserList().then(function (http) {
            $scope.filteredUserLists = $scope.userLists = http.data;
        }, function (error) {
            console.log("Error from server! (user lists)");
        });

        $scope.getImage = function (fileName) {
            $scope.imageId = fileName;
        }



        $scope.subscribe = function (index) {
            UserListService.subscribe($scope.filteredUserLists[index].UserName).then(function (http) {
                $scope.filteredUserLists[index].SubscriptionId = http.data;
            }, function (error) {
                console.log("Error from server! (subscribe)");
            });
        }

        $scope.unsubscribe = function (index) {
            UserListService.unsubscribe($scope.filteredUserLists[index].SubscriptionId).then(function (http) {
                if (http.data) {
                    $scope.filteredUserLists[index].SubscriptionId = null;
                }
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
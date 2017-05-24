app.controller("UserListController", [
    "$scope", "UserListService", function ($scope, UserListService) {
        
        $scope.searchString = $scope.getParamFromUrl("searchString");

        $scope.getUserList = function (pageCount) {
            if (pageCount === 0) {
                $scope.userLists = [];
            }
            var minAge = $scope.minAge === null ? -1 : parseInt($scope.minAge);
            var maxAge = $scope.maxAge === null ? -1 : parseInt($scope.maxAge);
            UserListService.getUserList(pageCount, $scope.searchString, $scope.countrySelect, $scope.citySelect, minAge, maxAge, parseInt($scope.sexSelect), parseInt($scope.sortSelect)).then(function (http) {
                $scope.userLists = $scope.userLists.concat(http.data.Users);
                $scope.usersCount = http.data.UsersCount;
            }, function (error) {
                console.log("Error from server! (user lists)");
            });
        }

        UserListService.getCountries().then(function (http) {
            $scope.countries = http.data;
        }, function (error) {
            console.log("Error from server! (countries)");
        });

        $scope.minAge = null;
        $scope.maxAge = null;
        $scope.sexSelect = "0";
        $scope.sortSelect = "0";
        $scope.usersCount = 0;
        var pageCount = 0;
        $scope.getUserList(pageCount);


        $scope.getMoreUserList = function() {
            pageCount++;
            $scope.getUserList(pageCount);
        }

        $scope.selectCountry = function () {
            $scope.citySelect = "";
            if ($scope.countrySelect === "") {
                $scope.cities = null;
                $("#citySelect").prop("disabled", true);
            } else {
                for (var i in $scope.countries)
                {
                    if ($scope.countries[i].Name === $scope.countrySelect) {
                        $scope.cities = $scope.countries[i].Cities;
                        $("#citySelect").prop("disabled", false);
                        break;
                    }
                }
            }
            $scope.getUserList(0);
        }

        $scope.sortUserList = function() {
            if ($scope.usersCount === $scope.userLists.length) {
                switch ($scope.sortSelect) {
                    case 0:
                        $scope.userLists.sort(function(a, b) {
                            if (a.RegisterDate > b.RegisterDate) {
                                return 1;
                            }
                            if (a.RegisterDate < b.RegisterDate) {
                                return -1;
                            }
                            return 0;
                        });
                        break;
                    case 1:
                        $scope.userLists.sort(function (a, b) {
                            if (a.Popularity > b.Popularity) {
                                return 1;
                            }
                            if (a.Popularity < b.Popularity) {
                                return -1;
                            }
                            return 0;
                        });
                        break;
                    default:
                        $scope.getUserList(0);
                }
            } else {
                $scope.getUserList(0);
            }
        }
        
        $scope.subscribe = function (index) {
            var userName = $scope.userLists[index].UserName;
            if (userName === $scope.currentUser.User.UserName) return;
            UserListService.subscribe(userName).then(function (http) {
                $scope.userLists[index].SubscriptionId = http.data;
            }, function (error) {
                console.log("Error from server! (subscribe)");
            });
        }

        $scope.unsubscribe = function (index) {
            var user = $scope.userLists[index];
            if (user.UserName === $scope.currentUser.User.UserName) return;
            UserListService.unsubscribe(user.SubscriptionId).then(function (http) {
                if (http.data) {
                    $scope.userLists[index].SubscriptionId = null;
                }
            }, function (error) {
                console.log("Error from server! (unsubscribe)");
            });
        }

        $scope.changeCountry = function (country) {
            $scope.countrySelect = country;
            $scope.selectCountry();
        }

        $scope.changeCity = function (country, city) {
            $scope.countrySelect = country;
            for (var i in $scope.countries) {
                if ($scope.countries[i].Name === $scope.countrySelect) {
                    $scope.cities = $scope.countries[i].Cities;
                    $("#citySelect").prop("disabled", false);
                    break;
                }
            }
            $scope.citySelect = city;
            $scope.getUserList(0);
        }

        $scope.changeAge = function(value) {
            $scope.minAge = $scope.maxAge = value;
            $scope.getUserList(0);
        }
    }
]);
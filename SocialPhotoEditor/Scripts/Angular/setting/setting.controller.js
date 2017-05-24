app.controller("SettingController", [
    "$scope", "SettingService", function ($scope, SettingService) {

        $(document).ready(function () {
            $("#subscribe").emojioneArea();
        });

        SettingService.getCountries().then(function(http) {
            $scope.countries = http.data;
        }, function(error) {
            console.log("Error from server! (countries)");
        });

        SettingService.getUserInfo().then(function (http) {
            $scope.user = http.data;
            console.log($scope.user);
            $scope.nameInput = http.data.Name;
            $scope.surnameInput = http.data.Surname;
            $scope.subscribeTextarea = http.data.Subscribe;
            $("#sex").val(http.data.Sex);
            $scope.birthdayInput = new Date(http.data.Birthday);
            $scope.countrySelect = http.data.CountryName;
            $scope.selectCountry();
            $scope.citySelect = http.data.CityName;
        }, function (error) {
            console.log("Error from server! (countries)");
        });

        $scope.selectCountry = function () {
            $scope.citySelect = "";
            if ($scope.countrySelect === "") {
                $scope.cities = null;
                $("#citySelect").prop("disabled", true);
            } else {
                for (var i in $scope.countries) {
                    if ($scope.countries[i].Name === $scope.countrySelect) {
                        $scope.cities = $scope.countries[i].Cities;
                        $("#citySelect").prop("disabled", false);
                        break;
                    }
                }
            }
        }

        $scope.updateUserInfo = function() {
            
        }
    }
]);
app.controller("SettingController", [
    "$scope", "SettingService", function ($scope, SettingService) {

        SettingService.getCountries().then(function(http) {
            $scope.countries = http.data;
        }, function(error) {
            console.log("Error from server! (countries)");
        });

        $(document).ready(function () {
            $("#subscribe").emojioneArea();
            $("#saveAlert").hide();

            SettingService.getUserInfo().then(function (http) {
                $scope.user = http.data;
                $scope.nameInput = http.data.Name;
                $scope.surnameInput = http.data.Surname;
                $("#subscribe").data("emojioneArea").setText(http.data.Subscribe);
                $("#sex").val(http.data.Sex);
                $scope.birthdayInput = http.data.Birthday == null ? "" : new Date(http.data.Birthday);
                $scope.countrySelect = http.data.CountryName;
                $scope.selectCountry();
                $scope.citySelect = http.data.CityName;
            }, function (error) {
                console.log("Error from server! (get info)");
            });
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

        $scope.updateUserInfo = function () {
            SettingService.updateUserInfo($scope.user.AvatarFileName, $scope.nameInput, $scope.surnameInput, $("#subscribe").data("emojioneArea").getText(),
                $scope.citySelect, $scope.countrySelect, $("#sex").val(), $scope.birthdayInput).then(function (http) {
                if (http.data) {
                    $("#saveAlert").show(); 
                    setTimeout(function () { $("#saveAlert").hide(); }, 2000);
                }
            }, function (error) {
                console.log("Error from server! (update info)");
            });
            
        }
    }
]);
app.service("SettingService", [
    "$http", function($http) {

        this.getCountries = function() {
            return $http.get("/api/CountryWebApi/");
        }

        this.getUserInfo = function () {
            return $http.get("/api/UserWebApi/");
        }

        this.updateUserInfo = function (avatarFileName, name, surname, subscribe, cityName, countryName, sex, birthday) {
            var response = {
                avatar: avatarFileName,
                name: name,
                surname: surname,
                subscribe: subscribe,
                city: cityName,
                country: countryName,
                sex: sex,
                birthday: birthday
            };
            return $http.put("/api/UserWebApi/", response);
        }
    }
]);
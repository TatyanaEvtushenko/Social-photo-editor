app.service("UserListService", [
    "$http", function ($http) {

        this.getCountries = function () {
            return $http.get("/api/CountryWebApi/");
        }

        this.getUserList = function (pageNumber, searchString, country, city, minAge, maxAge, sex, sortType) {
            var response = {
                page: pageNumber,
                search: searchString,
                country: country,
                city: city,
                minAge: minAge,
                maxAge: maxAge,
                sex: sex,
                sort: sortType
            };
            return $http.post("/api/UserWebApi", response);
        }

        this.subscribe = function (userName) {
            return $http({ method: "PUT", url: "/api/RelationshipWebApi/", params: { 'userName': userName } });
        }

        this.unsubscribe = function (id) {
            return $http({ method: "DELETE", url: "/api/RelationshipWebApi/", params: { 'id': id } });
        }
    }
]);
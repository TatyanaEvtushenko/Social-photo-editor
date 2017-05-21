app.service("UserListService", [
    "$http", function ($http) {

        this.getCountries = function () {
            return $http({ method: "GET", url: "/api/CountryWebApi/" });
        }

        this.getUserList = function (pageNumber, searchString, country, city, minAge, maxAge, sex, sortType) {
            var response = {};
            response.PageNumber = pageNumber;
            response.SearchString = searchString;
            response.Country = country;
            response.City = city;
            response.MinAge = minAge;
            response.MaxAge = maxAge;
            response.Sex = sex;
            response.SortType = sortType;
            return $http({ method: "POST", url: "/api/UserWebApi", params: { 'searchResponse': response
                    //'pageNumber': pageNumber,
                    //'searchString': searchString,
                    //'country': country,
                    //'city': city,
                    //'minAge': minAge,
                    //'maxAge': maxAge,
                    //'sex': sex,
                    //'sortType': sortType
                }
            });
        }

        this.subscribe = function (userName) {
            return $http({ method: "PUT", url: "/api/RelationshipWebApi/", params: { 'userName': userName } });
        }

        this.unsubscribe = function (id) {
            return $http({ method: "DELETE", url: "/api/RelationshipWebApi/", params: { 'id': id } });
        }
    }
]);
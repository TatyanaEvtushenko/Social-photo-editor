app.service("NewsService", [
    "$http", function ($http) {

        this.getNews = function () {
            return $http({ method: "GET", url: "/api/ImageWebApi/"});
        }
    }
]);
app.service("NewsService", [
    "$http", function ($http) {

        this.getNews = function (pageNumber) {
            return $http({ method: "POST", url: "/api/ImageWebApi/", params: { 'pageNumber': pageNumber }});
        }
    }
]);
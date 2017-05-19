app.controller("NewsController", [
    "$scope", "NewsService", function ($scope, NewsService) {

        NewsService.getNews().then(function (http) {
            $scope.news = http.data;
        }, function (error) {
            console.log("Error from server! (news)");
        });
    }
]);
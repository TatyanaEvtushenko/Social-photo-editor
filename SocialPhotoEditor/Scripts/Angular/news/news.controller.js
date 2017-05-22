app.controller("NewsController", [
    "$scope", "NewsService", function($scope, NewsService) {
        
        function getNews(pageNumber) {
            if (pageNumber === 0) {
                $scope.news = [];
            }
            var oldNewsCount = $scope.news.length;
            NewsService.getNews(pageNumber).then(function (http) {
                $scope.news = $scope.news.concat(http.data);
                if (oldNewsCount === $scope.news.length) {
                    $("#moreNewsButton").hide();
                }
            }, function (error) {
                console.log("Error from server! (news)");
            });
        }

        var pageNumber = 0;
        getNews(pageNumber);

        $scope.getMoreNews = function () {
            pageNumber++;
            getNews(pageNumber);
        };
    }
]);
app.controller("NewsController", [
    "$scope", "NewsService", function ($scope, NewsService) {

        NewsService.getNews().then(function (http) {
            $scope.news = http.data;
        }, function (error) {
            console.log("Error from server! (news)");
        });

        $(document).ready(function () {
            $("#commentInput").emojioneArea({
                events: {
                    keypress: function (editor, event) {
                        if (event.which === 13 || event.keyCode === 13) {
                            addComment();
                        }
                    },
                    focus: function (editor, event) {
                        var pos = editor.text().length;
                        console.log(editor);
                        editor.select(pos);
                    }
                }
            });
            $("#commentInput").data("emojioneArea").setFocus(true);
        });
    }
]);
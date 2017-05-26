app.controller("NewImageController", [
    "$scope", "NewImageService", function ($scope, NewImageService) {

        NewImageService.getFoldersList().then(function (http) {
            $scope.folders = http.data;
        }, function (error) {
            console.log("Error from server! (countries)");
        });

        $scope.folderSelect = "";

        $(document).ready(function () {
            $("#subscribe").emojioneArea();
            $(".btn").button();
        });

        $scope.editImage = function() {
            
        }

        $scope.addImage = function() {
            NewImageService.addImage($("#img").attr("src"), $scope.folderSelect, $("#subscribe").data("emojioneArea").getText());
        }
    }
]);
app.controller("FolderController", [
    "$scope", "FolderService", function ($scope, FolderService) {
        
        $(document).ready(function () {
            $("#folderSubscribeTextarea").emojioneArea();
        });

        $scope.addFolder = function () {
            var name = $("#folderNameInput").val();
            var subscribe = $("#folderSubscribeTextarea").data("emojioneArea").getText();
            FolderService.addFolder(name, subscribe).then(function(http) {
                if (http.data != null) {
                    var newFolder = {
                        Id: http.data,
                        Name: name,
                        ImagesCount: 0
                    };
                    var folders = $scope.userPage.Folders;
                    folders[folders.length] = newFolder;
                    $("#folderModal").modal("hide");
                }
            }, function(error) {
                console.log("Error from server! (new folder)");
            });
        }
    }
]);
app.controller("FolderController", [
    "$scope", "FolderService", function ($scope, FolderService) {
        
        $(document).ready(function () {
            $("#folderSubscribeTextarea").emojioneArea();
        });

        $scope.addFolder = function () {
            if ($scope.folderOwnerId !== $scope.currentUser.User.UserName) return;
            var name = $("#folderNameInput").val();
            var subscribe = $("#folderSubscribeTextarea").data("emojioneArea").getText();
            FolderService.addFolder(name, subscribe, $scope.folderOwnerId).then(function (http) {
                if (http.data != null) {
                    var newFolder = {
                        Id: http.data,
                        Name: name,
                        ImagesCount: 0
                    };
                    var folders = $scope.userPage === undefined ? $scope.folders : $scope.userPage.Folders;
                    folders[folders.length] = newFolder;
                }
            }, function(error) {
                console.log("Error from server! (new folder)");
            });
            $("#folderModal").modal("hide");
        }
    }
]);
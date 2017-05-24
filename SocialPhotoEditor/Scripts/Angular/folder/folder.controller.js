﻿app.controller("FolderController", [
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
                    var folders = typeof $scope.userPage === "undefined" ? null : $scope.userPage.Folders;
                    folders[folders.length] = newFolder;
                    $("#folderModal").modal("hide");
                }
            }, function(error) {
                console.log("Error from server! (new folder)");
            });
        }
    }
]);
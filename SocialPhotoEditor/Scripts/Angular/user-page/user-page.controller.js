app.controller("UserPageController", [
    "$scope", "UserPageService", function ($scope, UserPageService) {

        var userName = $scope.getParamFromUrl("userName");
        var pageCount = 0;
        var allImagesPageCount = 0;
        var activeFolderId = "";
        var folderIndex = 0;

        $(".alert").alert();
        $("#deleteFolderAlert").hide();

        UserPageService.getUserPage(userName).then(function (http) {
            $scope.userPage = http.data;
            allImagesPageCount++;
            $scope.folder = { Images: $scope.userPage.UserImages };
            $scope.userPage.UserImages.length === $scope.userPage.ImagesCount ? $("#moreImagesButton").hide() : $("#moreImagesButton").show();
            activeFolderId = "#userImages";
        }, function (error) {
            console.log("Error from server! (user page)");
        });

        function changeFolder(newFolderId, allImagesInFolderCount) {
            pageCount = 0;
            $(activeFolderId).removeClass("active");
            activeFolderId = "#" + newFolderId;
            $(activeFolderId).addClass("active");
            $scope.folder.Images.length ===  allImagesInFolderCount? $("#moreImagesButton").hide() : $("#moreImagesButton").show();
        }

        $scope.getMoreUserImages = function () {
            UserPageService.getMoreUserImages(allImagesPageCount, $scope.userPage.UserName).then(function (http) {
                if (http.data != null) {
                    $scope.userPage.UserImages = $scope.userPage.UserImages.concat(http.data);
                    allImagesPageCount++;
                }
            }, function (error) {
                console.log("Error from server! (more user images)");
            });
            $scope.folder = { Images: $scope.userPage.UserImages };
            changeFolder("userImages", $scope.userPage.ImagesCount);
        }

        $scope.getFolder = function (index) {
            UserPageService.getFolder($scope.userPage.Folders[index].Id).then(function (http) {
                if (http.data != null) {
                    $scope.folder = http.data;
                    folderIndex = index;
                    changeFolder("folder" + index, $scope.userPage.Folders[index].ImagesCount);
                }
            }, function (error) {
                console.log("Error from server! (folder)");
            });
        }

        $scope.getMoreImages = function () {
            if (activeFolderId === "#userImages") {
                $scope.getMoreUserImages();
            } else {
                UserPageService.getMoreImagesFromFolder(pageCount + 1, $scope.folder.Id).then(function (http) {
                    if (http.data != null) {
                        $scope.folder.Images = $scope.folder.Images.concat(http.data);
                        pageCount++;
                        $scope.folder.Images.length === $scope.userPage.Folders[folderIndex] ? $("#moreImagesButton").hide() : $("#moreImagesButton").show();
                    }
                }, function (error) {
                    console.log("Error from server! (more images in folder)");
                });
            }
        }

        $scope.tryDeleteFolder = function () {
            if (typeof $scope.folder.OwnerId === "undefined" || $scope.folder.OwnerId !== $scope.currentUser.User.UserName) return;
            if (typeof $scope.folder.Id === "undefined") return;
            $("#deleteFolderAlert").show();
        }
        
        $scope.hideFolderAlert = function () {
            $("#deleteFolderAlert").hide();
        }

        $scope.deleteFolder = function () {
            $("#deleteFolderAlert").hide();
            if (typeof $scope.folder.OwnerId === "undefined" || $scope.folder.OwnerId !== $scope.currentUser.User.UserName) return;
            if (typeof $scope.folder.Id === "undefined") return;
            UserPageService.deleteFolder($scope.folder.Id).then(function (http) {
                if (http.data) {
                    $scope.userPage.Folders.splice(folderIndex, 1);
                    $scope.folder = { Images: $scope.userPage.UserImages };
                    changeFolder("userImages", $scope.userPage.ImagesCount);
                }
            }, function (error) {
                console.log("Error from server! (delete folder)");
            });
        }


        $scope.subscribe = function () {
            UserPageService.subscribe(userName).then(function (http) {
                $scope.userPage.IsSubscriber = true;
                $scope.userPage.SubscribersCount++;
            }, function (error) {
                console.log("Error from server! (subscribe)");
            });
        }

        $scope.unsubscribe = function () {
            UserPageService.unsubscribe(userName).then(function (http) {
                $scope.userPage.IsSubscriber = false;
                $scope.userPage.SubscribersCount--;
            }, function (error) {
                console.log("Error from server! (unsubscribe)");
            });
        }

        $scope.getSubscribers = function () {
            UserPageService.getSubscribers(userName).then(function (http) {
                $scope.users = http.data;
            }, function (error) {
                console.log("Error from server! (subscribers)");
            });
        }

        $scope.getSubscriptions = function () {
            UserPageService.getSubscriptions(userName).then(function (http) {
                $scope.users = http.data;
            }, function (error) {
                console.log("Error from server! (subscriptions)");
            });
        }
    }
]);
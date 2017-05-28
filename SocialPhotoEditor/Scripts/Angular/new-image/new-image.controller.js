app.controller("NewImageController", [
    "$scope", "NewImageService", function ($scope, NewImageService) {

        $scope.folderSelect = "";
        $scope.folders = [];
        var sourceImage = null;

        NewImageService.getFoldersList().then(function (http) {
            $scope.folders = http.data;
        }, function (error) {
            console.log("Error from server! (folders)");
        });

        $(document).ready(function () {
            $("#subscribe").emojioneArea();
            $(".btn").button();
        });

        $scope.addImage = function() {
            NewImageService.addImage($("#img").attr("src"), $scope.folderSelect, $("#subscribe").data("emojioneArea").getText()).then(function(http) {
                if (http.data != null) {
                    window.location.href = window.location.origin + "/User/Page/?userName=" + $scope.currentUser.User.UserName;
                }
            }, function (error) {
                console.log("Error from server! (add image)");
            });
        }

        $scope.cancelAdding = function () {
            var path = sourceImage == null ? $("#img").attr("src") : sourceImage;
            NewImageService.cancelAdding(path).then();
            window.location.href = window.location.origin + "/User/Page/?userName=" + $scope.currentUser.User.UserName;
        }

        function editImage(effect) {
            if (sourceImage == null) {
                sourceImage = $("#img").attr("src");
            }
            var newPath = sourceImage.replace(/upload/, "upload/" + effect);
            $("#img").attr("src", newPath);
        }

        $scope.editDefault = function () {
            if (sourceImage == null) {
                sourceImage = $("#img").attr("src");
            }
            $("#img").attr("src", sourceImage);
        }

        $scope.editAutoBrightness = function () {
            editImage("e_auto_brightness");
        }

        $scope.editAutoColor = function () {
            editImage("e_auto_color");
        }

        $scope.editAutoContrast = function () {
            editImage("e_auto_contrast");
        }

        $scope.editArtistic = function() {
            editImage("e_art:incognito");
        }

        $scope.editBlackWhite = function () {
            editImage("e_blackwhite");
        }

        $scope.editBlurFaces = function () {
            editImage("e_blur_faces:1000");
        }

        $scope.editBlur = function () {
            editImage("e_blur_region:800");
        }

        $scope.editCartoonify = function () {
            editImage("e_cartoonify");
        }

        $scope.editGrayscale = function () {
            editImage("e_grayscale");
        }

        $scope.editHue = function () {
            editImage("e_hue:80");
        }

        $scope.editImprove = function () {
            editImage("e_improve");
        }

        $scope.editNegate = function () {
            editImage("e_negate");
        }

        $scope.editOilPaint = function () {
            editImage("e_oil_paint:50");
        }

        $scope.editOrderedDither = function () {
            editImage("e_ordered_dither:0");
        }

        $scope.editOutline= function () {
            editImage("e_outline");
        }

        $scope.editPixelate = function () {
            editImage("e_pixelate:20");
        }

        $scope.editPixelateFaces = function () {
            editImage("e_pixelate_faces:30");
        }

        $scope.editSaturation = function () {
            editImage("e_saturation:100");
        }

        $scope.editSepia = function () {
            editImage("e_sepia:80");
        }

        $scope.editTint = function () {
            editImage("e_tint");
        }

        $scope.editVignette = function () {
            editImage("e_vignette:80");
        }

        $scope.editRed = function () {
            editImage("e_red:40");
        }

        $scope.editRedEyes = function () {
            editImage("e_redeye");
        }

        $scope.editGreen = function () {
            editImage("e_green:40");
        }

        $scope.editBlue = function () {
            editImage("e_blue:040");
        }
    }
]);
app.controller("ImageController", [
    "$scope", "ImageService", function($scope, ImageService) {

        var answerUserName = "";
        var index = 0;

        function addComment() {
            var input = $("#" + index).data("emojioneArea");
            var text = input.getText().trim();
            var recipientText = "@" + answerUserName + ", ";
            if (text.indexOf(recipientText) === 0) {
                text = text.substring(recipientText.length);
            } else {
                answerUserName = null;
            }
            var image = typeof $scope.news !== "undefined" ? $scope.news[index] : $scope.image;
            ImageService.addComment(text, image.FileName, answerUserName).then(function (http) {
                if (http.data != null) {
                    var comment = {
                        Text: text,
                        Time: new Date(Date.now()),
                        RecipientUserName: answerUserName,
                        OwnerUserName: $scope.currentUser.User.UserName,
                        Id: http.data
                    };
                    image.Comments[image.Comments.length] = comment;
                    input.setText("");
                    var div = $("#commentDiv" + index);
                    div.scrollTop(div.prop("scrollHeight"));
                }
            }, function (error) {
                console.log("Error from server! (add comment)");
            });
        };

        function sortComment() {
            if ($scope.image != null && $scope.image.length !== 0) {
                $scope.image.Comments.sort(function (a, b) {
                    if (a.Time < b.Time) {
                        return -1;
                    }
                    if (a.Time > b.Time) {
                        return 1;
                    }
                    return 0;
                });
            }
        }

        $(document).ready(function () {
            $("textarea").emojioneArea({
                events: {
                    keypress: function (editor, event) {
                        if (event.which === 13 || event.keyCode === 13) {
                            index = editor[0].parentElement.parentElement.firstElementChild.id;
                            addComment();
                        }
                    },
                    focus: function (editor, event) {
                        //var pos = editor.text().length;
                        //console.log(pos);
                    }
                }
            });
            sortComment();
        });

        $("#imageModal").on("show.bs.modal", function (e) {
            ImageService.getImage($scope.imageId).then(function (http) {
                $scope.image = http.data;
                sortComment();
            }, function (error) {
                console.log("Error from server! (image)");
            });
            $(".alert").alert();
            $("#deleteImageAlert").hide();
            $("textarea").data("emojioneArea").setFocus(true);
        });

        $scope.changeAvatar = function () {
            var image = $scope.image;
            var currentUser = $scope.currentUser.User;
            if (image.FileName === currentUser.AvatarFileName || image.Owner.UserName !== currentUser.UserName) return;
            ImageService.changeAvatar(image.FileName).then(function (http) {
                if (http.data) {
                    window.location.reload();
                }
            }, function (error) {
                console.log("Error from server! (avatar)");
            });
        }

        $scope.addLike = function () {
            ImageService.addLike($scope.image.FileName).then(function (http) {
                if (http.data != null) {
                    $scope.image.LikeId = http.data;
                    $scope.image.LikesCount++;
                }
            }, function (error) {
                console.log("Error from server! (add like)");
            });
        }

        $scope.deleteLike = function () {
            ImageService.deleteLike($scope.image.LikeId).then(function (http) {
                if (http.data) {
                    $scope.image.LikeId = null;
                    $scope.image.LikesCount--;
                }
            }, function (error) {
                console.log("Error from server! (delete like)");
            });
        }

        $scope.answer = function (userName, i) {
            answerUserName = userName;
            index = i;
            var input = $("#" + index).data("emojioneArea");
            var recipientText = "@" + answerUserName + ", ";
            input.setText(recipientText);
            input.setFocus();
        }

        $scope.deleteComment = function(index) {
            var id = $scope.image.Comments[index].Id;
            ImageService.deleteComment(id).then(function(http) {
                if (http.data) {
                    $scope.image.Comments.splice(index, 1);
                }
            }, function(error) {
                console.log("Error from server! (delete comment)");
            });
        };

        $scope.hideDeleteAlert = function () {
            $("#deleteImageAlert").hide();
        }

        $scope.tryDeleteImage = function() {
            if ($scope.image.Owner.UserName !== $scope.currentUser.User.UserName) return;
            $("#deleteImageAlert").show();
        }

        $scope.deleteImage = function () {
            if ($scope.image.Owner.UserName !== $scope.currentUser.User.UserName) return;
            ImageService.deleteImage($scope.image.FileName).then(function (http) {
                if (http.data) {
                    window.location.reload();
                }
            }, function (error) {
                console.log("Error from server! (delete image)");
            });
        }
    }
]);
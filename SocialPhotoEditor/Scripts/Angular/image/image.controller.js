app.controller("ImageController", [
    "$scope", "ImageService", function ($scope, ImageService) {
        
        var answerUserName = "";
        
        function addComment() {
            var input = $("#commentInput").data("emojioneArea");
            var text = input.getText().trim();
            var recipientText = "@" + answerUserName + ", ";
            if (text.indexOf(recipientText) === 0) {
                text = text.substring(recipientText.length);
            } else {
                answerUserName = null;
            }
            ImageService.addComment(text, $scope.image.FileName, answerUserName).then(function (http) {
                if (http.data != null) {
                    var comment = {
                        Text: text,
                        Time: new Date(Date.now()),
                        RecipientUserName: answerUserName,
                        OwnerUserName: $scope.currentUser.User.UserName,
                        Id: http.data
                    };
                    $scope.image.Comments[$scope.image.Comments.length] = comment;
                    input.setText("");
                    var div = $("#commentDiv");
                    div.scrollTop(div.prop("scrollHeight"));
                }
            }, function (error) {
                console.log("Error from server! (add comment)");
            });
        }

        $("#imageModal").on("show.bs.modal", function (e) {
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
            ImageService.getImage($scope.imageId).then(function (http) {
                $scope.image = http.data;
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
            }, function(error) {
                console.log("Error from server! (image)");
            });
            $(".alert").alert();
            $("#deleteImageAlert").hide();
        });

        $scope.changeAvatar = function () {
            var image = $scope.image.FileName;
            if (image === $scope.currentUser.User.AvatarFileName) return;
            ImageService.changeAvatar(image).then(function (http) {
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

        $scope.answer = function (userName) {
            answerUserName = userName;
            var input = $("#commentInput").data("emojioneArea");
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
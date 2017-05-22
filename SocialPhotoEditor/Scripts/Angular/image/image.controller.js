app.controller("ImageController", [
    "$scope", "ImageService", function ($scope, ImageService) {
        
        var answerUserName = "";

        function addComment(text) {
            text.trim();
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
                    $("#commentInput").data("emojioneArea").setText("");
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
                                var text = $("#commentInput").data("emojioneArea").getText();
                                addComment(text);
                            }
                        },
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
        });

        $scope.changeAvatar = function () {
            $.cloudinary.image('sample.jpg', { width: 100, height: 150, crop: 'fill' });
            alert("fghj");
            //ImageService.changeAvatar($scope.image.FileName).then(function (http) {
            //}, function (error) {
            //    console.log("Error from server! (avatar)");
            //});
            //window.location.reload();
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

        function setSelectionRange(input, selectionStart, selectionEnd) {
            if (input.setSelectionRange) {
                input.setFocus();
                input.setSelectionRange(selectionStart, selectionEnd);
            }
            else if (input.createTextRange) {
                var range = input.createTextRange();
                range.collapse(true);
                range.moveEnd('character', selectionEnd);
                range.moveStart('character', selectionStart);
                range.select();
            }
        }

        function setCaretToPos(input, pos) {
            setSelectionRange(input, pos, pos);
        }

        $scope.answer = function (userName) {
            answerUserName = userName;
            var input = $("#commentInput").data("emojioneArea");
            var recipientText = "@" + answerUserName + ", ";
            input.setText(recipientText);
            input.setFocus();
            setCaretToPos(input, recipientText.length);
        }

        $scope.deleteComment = function (index) {
            var id = $scope.image.Comments[index].Id;
            ImageService.deleteComment(id).then(function (http) {
                if (http.data) {
                    $scope.image.Comments.splice(index, 1);
                }
            }, function (error) {
                console.log("Error from server! (delete comment)");
            });
        }
    }
]);
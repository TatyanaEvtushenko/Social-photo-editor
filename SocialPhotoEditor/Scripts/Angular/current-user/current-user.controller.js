app.controller("CurrentUserController", [
    "$scope", "CurrentUserService", function($scope, CurrentUserService) {

        CurrentUserService.getCurrentUserMinInfo().then(function(http) {
            $scope.currentUser = http.data;
        });

        $scope.getParamFromUrl = function (paramName) {
            var url = window.location.search;
            var params = url.substring(url.indexOf("?") + 1).split("&");
            if (params === "")
                return null;
            for (var i in params) {
                var param = params[i].split("=");
                if (param[0] === paramName) {
                    return param[1];
                }
            }
            return null;
        }

        $scope.getAge = function(birthday) {
            if (birthday == null)
                return null;
            var date = new Date(birthday);
            var dateNow = new Date(Date.now());
            var yearSubtract = dateNow.getFullYear() - date.getFullYear();
            if ((dateNow.getMonth() < date.getMonth()) || (dateNow.getMonth() === date.getMonth() && dateNow.getDate() < date.getDate()))
                return yearSubtract - 1;
            return yearSubtract;
        };

        $scope.getSquareImage = function(id) {
            var width = $("#" + id).attr("width");
            var height = $("#" + id).attr("height");
            width = min(width, height);
            $("#" + id).width(width);
            $("#" + id).height(width);
        };
        
        $scope.getImage = function (fileName) {
            $scope.imageId = fileName;
        }

        $scope.getAvatar = function (fileName) {
            return fileName == null ? "/Content/avatar.jpg" : fileName;
        }

        $scope.redirectToSearch = function() {
            window.location.replace("User/Index?searchString=" + $scope.searchString);
        }
    }
]);
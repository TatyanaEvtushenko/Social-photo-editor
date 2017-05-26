app.controller("CurrentUserController", [
    "$scope", "CurrentUserService", function($scope, CurrentUserService) {

        $(document).ready(function() {
            //$("#example").popover(options);
        });

        CurrentUserService.getCurrentUserMinInfo().then(function(http) {
            $scope.currentUser = http.data;
        });

        $scope.redirectToSearch = function() {
            $("#formSearch").submit();
        }

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
        
        $scope.getDate = function (time) {
            var date = new Date(time);
            var dateNow = new Date(Date.now());
            var count = dateNow.getFullYear() - date.getFullYear();
            if (count >= 1)
                return count.toString() + " г.";
            count = dateNow.getMonth() - date.getMonth();
            if (count >= 1)
                return count.toString() + " мес.";
            count = dateNow.getDate() - date.getDate();
            if (count >= 1)
                return count.toString() + " дн.";
            count = dateNow.getHours() - date.getHours();
            if (count >= 1)
                return count.toString() + " ч.";
            count = dateNow.getMinutes() - date.getMinutes();
            if (count >= 1)
                return count.toString() + " мин.";
            count = dateNow.getSeconds() - date.getSeconds();
            return count.toString() + " сек.";
        }
        
        $scope.getImage = function (fileName) {
            $scope.imageId = fileName;
        }

        $scope.openAddFolder = function(ownerUserName) {
            $scope.folderOwnerId = ownerUserName;
        };

        $scope.getAvatar = function (fileName) {
            return fileName == null ? "/Content/avatar.jpg" : fileName;
        }

        $scope.getStrDate = function (date) {
            date = new Date(date);
            var monthes = ["января", "февраля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря"];
            return date.getDate() + " " + monthes[date.getMonth()] + " " + date.getFullYear() + " г.";
        };
    }
]);
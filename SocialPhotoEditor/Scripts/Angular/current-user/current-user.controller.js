app.controller("CurrentUserController", [
    "$scope", "CurrentUserService", function($scope, CurrentUserService) {

        CurrentUserService.getCurrentUserMinInfo().then(function(http) {
            $scope.currentUser = http.data;
        }, function(error) {
            console.log("Error from server (current user)");
        });

        $scope.redirectToSearch = function() {
            window.location.href = window.location.origin + "/User/Index/?searchString=" + $scope.searchString;
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
            var yearSubtract = dateNow.getUTCFullYear() - date.getFullYear();
            if ((dateNow.getUTCMonth() < date.getMonth()) || (dateNow.getUTCMonth() === date.getMonth() && dateNow.getUTCDate() < date.getDate()))
                return yearSubtract - 1;
            return yearSubtract;
        };
        
        $scope.getDate = function (time) {
            var date = new Date(time);
            var dateNow = new Date(Date.now());
            var count = dateNow.getUTCFullYear() - date.getFullYear();
            if (count >= 1)
                return count.toString() + " г.";
            count = dateNow.getUTCMonth() - date.getMonth();
            if (count >= 1)
                return count.toString() + " мес.";
            count = dateNow.getUTCDate() - date.getDate();
            if (count >= 1)
                return count.toString() + " дн.";
            count = dateNow.getUTCHours() - date.getHours();
            if (count >= 1)
                return count.toString() + " ч.";
            count = dateNow.getUTCMinutes() - date.getMinutes();
            if (count >= 1)
                return count.toString() + " мин.";
            count = dateNow.getUTCSeconds() - date.getSeconds();
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

        $scope.hideEvents = function () {
            $("#event-popover").hide();
        };

        $scope.showEvents = function () {
            CurrentUserService.getEvents().then(function (http) {
                console.log(http.data);
                $scope.events = http.data;
                $scope.events.sort(function (a, b) {
                    if (a.Time < b.Time)
                        return 1;
                    if (a.Time > b.Time)
                        return -1;
                    return 0;
                });
                $("#event-popover").show();
                $scope.currentUser.NewEventsCount = 0;
            }, function (error) {
                console.log("Error from server (events)");
            });
        }

        $scope.changeEventsView = function () {
            var popover = $("#event-popover");
            if (popover.css("display") === "none") {
                popover.focus();
                $scope.showEvents();
            } else {
                popover.blur();
                $scope.hideEvents();
            }
        }

        $scope.getEventText = function (type) {
            switch (type) {
                case 0:
                    return "оценил(а) изображение";
                case 1:
                    return "прокомментировал(а) изображение";
                case 2:
                    return "подписался на Вас";
                case 3:
                    return "ответил(а) на Ваш комментарий";
                default:
            }
        }
    }
]);
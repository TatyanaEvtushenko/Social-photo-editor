app.service("UsersService", [
    "$http", function ($http) {

        this.getUserList = function() {
            return $http({ method: "GET", url: "/api/UserWebApi" });
        }

        this.getUserPage = function(userName) {
            return $http({ method: "POST", url: "/api/UserWebApi/", params: { 'userName': userName } });
        }

        this.getImages = function (userName, folderName) {
            return $http({ method: "POST", url: "/api/ImageWebApi/", params: { 'userName': { 'UserName': userName }, 'folderName': folderName } });
        }
    }
]);
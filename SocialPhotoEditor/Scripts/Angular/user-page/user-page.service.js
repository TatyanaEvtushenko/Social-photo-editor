app.service("UserPageService", [
    "$http", function ($http) {

        this.getUserPage = function (userName) {
            return $http({ method: "POST", url: "/api/UserWebApi/", params: { 'userName': userName } });
        }

        this.getFolder = function (folderId) {
            return $http({ method: "POST", url: "/api/FolderWebApi/", params: { 'folderId': folderId } });
        }
    }
]);
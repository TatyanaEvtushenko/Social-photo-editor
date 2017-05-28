app.service("NewImageService", [
    "$http", function ($http) {

        this.getFoldersList = function () {
            return $http.get("/api/FolderWebApi/");
        }

        this.addImage = function (imageFileName, folderId, subscribe) {
            var response = {
                "image": imageFileName,
                "folder": folderId,
                "subscribe": subscribe
            };
            return $http.put("/api/ImageWebApi/", response);
        }

        this.cancelAdding = function (imageFileName) {
            return $http({ method: "POST", url: "/api/ImageWebApi/CancelAdding/", params: { 'imageFileName': imageFileName } });
        }
    }
]);
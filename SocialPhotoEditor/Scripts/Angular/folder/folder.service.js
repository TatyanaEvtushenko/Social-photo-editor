app.service("FolderService", [
    "$http", function ($http) {

        this.addFolder = function (name, subscribe) {
            var response = {
                "name": name,
                "subscribe": subscribe
            }
            return $http.put("/api/FolderWebApi/", response);
        }
    }
]);
app.service("FolderService", [
    "$http", function ($http) {

        this.addFolder = function (name, subscribe, ownerUserName) {
            var response = {
                "name": name,
                "subscribe": subscribe,
                "owner": ownerUserName
            };
            return $http.put("/api/FolderWebApi/", response);
        }
    }
]);
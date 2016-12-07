angular.module('fileManagerApp').service("apiService", ['$http', function ($http) {

    this.getFileList = function () {
        return $http.get("/api/Files");
    };

    this.getFileListWithPath = function (path) {
        return $http.get("/api/Files", {
            params: {
                NextPath: path
            }
        });
    };

    this.getFileQuantity = function () {
        return $http.get("/api/FileCounter");
    };

    this.getFileQuantityWithPath = function (path) {
        return $http.get("/api/FilesCounter", {
            params: {
                pathRequest: path
            }
        });
    };
}]);
(function (angular) {
    'use strict';
    angular
        .module('fileManagerApp')
        .controller('fileDataController', fileDataController);

    fileDataController.$inject = ['apiService'];

    function fileDataController(ApiService) {
        var vm = this;
        vm.initializeFileList = initializeFileList;
        vm.moveToDir = moveToDir;
        vm.moveToLastDir = moveToLastDir;
        vm.fileList = [];

        var lastFilePaths = [];
        vm.loadGif = true;

        function initializeFileList() {
            ApiService.getFileList().success(function (data) {
                vm.fileList = data;
                loadFileQuantity(data.CurrentPath);
            }).error(function (data) {
                console.log(data);
                alert("Can not get access to directory");
            });
        }
        function moveToDir(path) {
            ApiService.getFileListWithPath(path).success(function (data) {
                lastFilePaths.push(vm.fileList.CurrentPath);
                vm.fileList = data;
                loadFileQuantity(data.CurrentPath);
            }).error(function (data) {
                console.log(data);
                alert("Can not get access to directory");
            });
        }

        function moveToLastDir() {
            if (lastFilePaths[lastFilePaths.length - 1] != undefined) {
                ApiService.getFileListWithPath(lastFilePaths[lastFilePaths.length - 1]).success(function (data) {
                    lastFilePaths.pop();
                    vm.fileList = data;
                    loadFileQuantity(data.CurrentPath);
                }).error(function (error) {
                    console.log(error);
                    alert("Can not get access to directory");
                });
            };
        }

        function loadFileQuantity(path) {
            vm.loadGif = false;
            ApiService.getFileQuantityWithPath(path).success(function (data) {
                if (data.RequestPath === vm.fileList.CurrentPath) {
                    vm.loadGif = true;
                    vm.fileQuantity = data;
                };
            });
        }
    }
})(angular);
menuApp.controller('menuItemsCtrl', function ($scope, menuService) {
    menuService.getCategories().success(function (data) {
        $scope.categories = data;
    });

    $scope.create = function () {
        var menuItem = {
            CategoryId: $scope.selectedCategoryId,
            Name: $scope.name,
            Description: $scope.description,
            Price: $scope.price,
        };
        menuService.createMenuItem(menuItem).success(function (data) {
        });
    };
});
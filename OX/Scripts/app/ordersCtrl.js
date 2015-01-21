menuApp.controller('ordersCtrl', function ($scope, $http, $interval, $location, menuService) {
    
    function getParameterByName(name) {
        name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    };
    
    function getDateTime(dateValue) {
        var value = '\/Date(0)\/';
        if (dateValue) {
            value = '\/Date(' + Date.parse(dateValue) + ')\/';
        }
        return value;
    };

    var intervalDelay = 1000;
    var intervalFunc = function () {
        menuService.getOrders().success(function (data) {
            $scope.orders = data;
        });
    };

    $scope.timer;

    $scope.startTimer = function () {
        if ($scope.timer) {
            $interval.cancel($scope.timer);
        }
        $scope.timer = $interval(intervalFunc, intervalDelay);
        $scope.timerStart = true;
    };
    $scope.stopTimer = function () {
        if ($scope.timer) {
            $interval.cancel($scope.timer);
        }
        $scope.timerStart = false;
    };

    menuService.getOrders().success(function (data) {
        $scope.orders = data;
    });

    $scope.showDetails = function (order) {
        $scope.selectedOrder = order;
        $scope.showOrderDetails = true;
    };

    $scope.open = function ($event) {
        $event.preventDefault();
        $event.stopPropagation();

        $scope.opened = true;
    };

    $scope.filterByTime = function (order) {
        var orderDate = moment(order.Time).toDate();
        var filterDate = moment($scope.selectedDate).toDate();
        var orderYear = orderDate.getFullYear();
        var orderMonth = orderDate.getMonth() + 1;
        var orderDay = orderDate.getDate();
        var filterMonth = filterDate.getMonth() + 1;
        var filterDay = filterDate.getDate();
        var filterYear = filterDate.getFullYear();

        var orderFullDate = orderYear + '-' + orderMonth + '-' + orderDay;
        var filterFullDate = filterYear + '-' + filterMonth + '-' + filterDay;
        return ($scope.selectedDate == null || orderFullDate == filterFullDate);
    };
});
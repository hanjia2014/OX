menuApp.factory("menuService", function ($http, $location) {
    var formsServiceUrl = $location.protocol() + ':' + '//' + $location.host() + ':' + $location.port();
    return ({
        getOrders: function () {
            return $http.get(formsServiceUrl + '/api/order');
        },

        getCategories: function () {
            return $http.get(formsServiceUrl + '/api/category');
        },

        createMenuItem: function(menuItem){
            return $http.post(formsServiceUrl + '/api/menuitem/' + menuItem);
        },

        deleteOrder: function (orderId) {
            return $http.delete(formsServiceUrl + '/api/order/' + orderId);
        },

        updateOrder: function (order) {
            return $http.put(formsServiceUrl + '/api/order/' + order.Id, order);
        },
    });
});
oxApp.factory("newsService", function ($http, $location) {
    var formsServiceUrl = $location.protocol() + ':' + '//' + $location.host() + ':' + $location.port();
    return ({
        GetAllNews: function () {
            return $http.get('/home/GetAllNews');
        },
        CreateMusician: function (musician) {
            return $http.post('/Musicians/Create', musician);
        },
    });
});
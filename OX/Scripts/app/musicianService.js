oxApp.factory("musicianService", function ($http, $location) {
    var formsServiceUrl = $location.protocol() + ':' + '//' + $location.host() + ':' + $location.port();
    return ({
        GetAllMusicians: function () {
            return $http.get('/home/GetAllMusicians');
        },
        CreateMusician: function (musician) {
            return $http.post('/Musicians/Create', musician);
        },
    });
});
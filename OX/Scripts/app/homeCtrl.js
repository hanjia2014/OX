oxApp.controller('homeCtrl', function ($scope, $http, musicianService, newsService) {
    var allNews = [];

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

    musicianService.GetAllMusicians().success(function (data) {
        $scope.musicians = data;
    });

    newsService.GetAllNews().success(function (data) {
        allNews = data;
        $scope.chunkedNewsData = chunk(allNews, 2);
    });

    function chunk(arr, size) {
        var newArr = [];
        for (var i = 0; i < arr.length; i += size) {
            newArr.push(arr.slice(i, i + size));
        }
        return newArr;
    }

    $scope.createMusician = function () {
        var musician = { Title: 'Ms', FirstName: 'John', LastName: 'Doe' };
        musicianService.CreateMusician(musician).success(function () {
            $scope.musicians.push(musician);
        });
    };
});
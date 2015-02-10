oxApp.directive('newsPreview', ['$compile', function ($compile) {
    function toDate(str) {
        var rv = null;
        str.replace(/^(\d\d)\/(\d\d)\/(\d\d)\$/, function (d, yy, mm, dd) {
            if (!d) throw "Bad date: " + str;
            yy = parseInt(yy, 10);
            yy = yy < 90 ? 2000 + yy : 1900 + yy;
            rv = new Date(yy, parseInt(mm, 10) - 1, parseInt(dd, 10));
            return null;
        });
        return rv;
    }

    return {
        restrict: 'AE',
        replace: true,
        scope: {
            newsItem: '='
        },
        link: function (scope, element, attr) {
            var template = '<div class="item">' +
                             '<div class="post1">' +
                              '<time datetime="' + attr.date + '">' + attr.date + '</time>' +
                              '<h3>' +
                               '<a href="#">' + attr.title + '</a>' +
                              '</h3>' +
                              '<p>' + attr.content + '</p>' +
                             '</div>' +
                            '</div>';

            element.html(template);
            $compile(element.contents())(scope);
        }
        //template: '<div class="item">' +
        //            '<div class="post1">' +
        //                '<time datetime="{{newsItem.Date}}">{{newsItem.Date}}</time>' +
        //                '<h3>' +
        //                    '<a href="#">{{newsItem.Title}}</a>' +
        //                '</h3>' +
        //                '<p>{{newsItem.Content}}</p>' +
        //             '</div>' +
        //           '</div>'
    };
}]);
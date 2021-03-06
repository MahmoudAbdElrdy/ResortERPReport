﻿'use strict';
app.factory('itemsGuideService', ['$http', 'sharedService', function ($http, sharedService) {

    var serviceBase = sharedService.getBaseUrl();

    var itemsGuideServiceFactory = {};

    var _get = function () {
        var myUrl = serviceBase + 'ItemsGuid/get';
        return $http.get(myUrl).then(function (results) {
            return results;
        });
    }

    itemsGuideServiceFactory.get = _get;
    return itemsGuideServiceFactory;

}]);
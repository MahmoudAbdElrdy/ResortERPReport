﻿'use strict';
app.factory('GoldBusyTotalDailyService', ['$http', 'sharedService', function ($http, sharedService) {

    var serviceBase = sharedService.getBaseUrl();

    var accountStatementServiceFactory = {};

    var _getReportResult = function (companyBranches, Accounts, Date) {
        var myUrl = serviceBase + 'billMaster/getTotalDailyReport?companyBranches=' + companyBranches +'&Accounts=' + Accounts + "&Date=" + Date;
        return $http.get(myUrl).then(function (results) {
            return results;
        });
    }

    accountStatementServiceFactory.getReportResult = _getReportResult;
    
    return accountStatementServiceFactory;

}]);
'use strict';
app.factory('movementAllEntriesDetailsTotalMonthService', ['$http', 'sharedService', function ($http, sharedService) {

    var serviceBase = sharedService.getBaseUrl();

    var accountStatementServiceFactory = {};

    var _getReportResult = function (companyBranches, Accounts, Date) {
        var myUrl = serviceBase + 'billMaster/MovementAllEntriesDetailsDay?companyBranches=' + companyBranches + "&ENDDATE=" + Date;
        return $http.get(myUrl).then(function (results) {
            return results;
        });
    }

    accountStatementServiceFactory.getReportResult = _getReportResult;
    
    return accountStatementServiceFactory;

}]);
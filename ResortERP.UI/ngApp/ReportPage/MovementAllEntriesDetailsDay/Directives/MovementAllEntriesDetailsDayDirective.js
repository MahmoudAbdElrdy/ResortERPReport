﻿app.directive('movementAllEntriesDetailsDay', function ($rootScope, $compile) {
    return {
        restrict: 'E',
        scope: false,
        templateUrl: function (scope, element) {
            var tempurl = '../../NgApp/ReportPage/MovementAllEntriesDetailsDay/Views/' + $rootScope.language + '/MovementAllEntriesDetailsDayReportPage.html';
            $rootScope.$watch(function () { return '../../NgApp/ReportPage/MovementAllEntriesDetailsDay/Views/' + $rootScope.language + '/MovementAllEntriesDetailsDayReportPage.html'; }
                , function (newVal, oldVal) {
                    if (newVal && newVal !== oldVal) {
                        element.$$element.html(newVal);
                        $compile(element.$$element)(scope);
                    }
                });
            return tempurl;
        }
    }
})
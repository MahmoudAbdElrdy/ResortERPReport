app.directive('movementAllEntriesDetailsTotalMonth', function ($rootScope, $compile) {
    return {
        restrict: 'E',
        scope: false,
        templateUrl: function (scope, element) {
            var tempurl = '../../NgApp/ReportPage/movementAllEntriesDetailsTotalMonth/Views/' + $rootScope.language + '/movementAllEntriesDetailsTotalMonthReportPage.html';
            $rootScope.$watch(function () { return '../../NgApp/ReportPage/movementAllEntriesDetailsTotalMonth/Views/' + $rootScope.language + '/movementAllEntriesDetailsTotalMonthReportPage.html'; }
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
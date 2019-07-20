app.directive('movementAllEntriesDetailsMonth', function ($rootScope, $compile) {
    return {
        restrict: 'E',
        scope: false,
        templateUrl: function (scope, element) {
            var tempurl = '../../NgApp/ReportPage/MovementAllEntriesDetailsMonth/Views/' + $rootScope.language + '/MovementAllEntriesDetailsMonthReportPage.html';
            $rootScope.$watch(function () { return '../../NgApp/ReportPage/MovementAllEntriesDetailsMonth/Views/' + $rootScope.language + '/MovementAllEntriesDetailsMonthReportPage.html'; }
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
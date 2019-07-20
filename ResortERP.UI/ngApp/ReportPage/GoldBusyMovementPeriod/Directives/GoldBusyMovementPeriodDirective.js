app.directive('goldBusyMovementPeriod', function ($rootScope, $compile) {
    return {
        restrict: 'E',
        scope: false,
        templateUrl: function (scope, element) {
            var tempurl = '../../NgApp/ReportPage/GoldBusyMovementPeriod/Views/' + $rootScope.language + '/GoldBusyMovementPeriodReportPage.html';
            $rootScope.$watch(function () { return '../../NgApp/ReportPage/GoldBusyMovementPeriod/Views/' + $rootScope.language + '/GoldBusyMovementPeriodReportPage.html'; }
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
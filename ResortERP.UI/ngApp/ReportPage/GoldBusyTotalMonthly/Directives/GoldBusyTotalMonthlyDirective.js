app.directive('goldBusyTotalMonthly', function ($rootScope, $compile) {
    return {
        restrict: 'E',
        scope: false,
        templateUrl: function (scope, element) {
            var tempurl = '../../NgApp/ReportPage/GoldBusyTotalMonthly/Views/' + $rootScope.language + '/GoldBusyTotalMonthlyReportPage.html';
            $rootScope.$watch(function () { return '../../NgApp/ReportPage/GoldBusyTotalMonthly/Views/' + $rootScope.language + '/GoldBusyTotalMonthlyReportPage.html'; }
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
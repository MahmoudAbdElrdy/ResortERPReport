app.directive('goldBusyTotalDaily', function ($rootScope, $compile) {
    return {
        restrict: 'E',
        scope: false,
        templateUrl: function (scope, element) {
            var tempurl = '../../NgApp/ReportPage/GoldBusyTotalDaily/Views/' + $rootScope.language + '/GoldBusyTotalDailyReportPage.html';
            $rootScope.$watch(function () { return '../../NgApp/ReportPage/GoldBusyTotalDaily/Views/' + $rootScope.language + '/GoldBusyTotalDailyReportPage.html'; }
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
app.directive('goldMovementDaily', function ($rootScope, $compile) {
    return {
        restrict: 'E',
        scope: false,
        templateUrl: function (scope, element) {
            var tempurl = '../../NgApp/ReportPage/GoldMovementDaily/Views/' + $rootScope.language + '/GoldMovementDailyReportPage.html';
            $rootScope.$watch(function () { return '../../NgApp/ReportPage/GoldMovementDaily/Views/' + $rootScope.language + '/GoldMovementDailyReportPage.html'; }
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
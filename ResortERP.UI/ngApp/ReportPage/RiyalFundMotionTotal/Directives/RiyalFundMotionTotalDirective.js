app.directive('riyalFundMotionTotal', function ($rootScope, $compile) {
    return {
        restrict: 'E',
        scope: false,
        templateUrl: function (scope, element) {
            var tempurl = '../../NgApp/ReportPage/RiyalFundMotionTotal/Views/' + $rootScope.language + '/RiyalFundMotionTotalReportPage.html';
            $rootScope.$watch(function () { return '../../NgApp/ReportPage/RiyalFundMotionTotal/Views/' + $rootScope.language + '/RiyalFundMotionTotalReportPage.html'; }
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
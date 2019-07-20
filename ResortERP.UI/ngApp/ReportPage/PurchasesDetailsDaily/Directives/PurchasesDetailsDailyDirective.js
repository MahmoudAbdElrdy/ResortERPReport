app.directive('purchasesDetailsDaily', function ($rootScope, $compile) {
    return {
        restrict: 'E',
        scope: false,
        templateUrl: function (scope, element) {
            var tempurl = '../../NgApp/ReportPage/PurchasesDetailsDaily/Views/' + $rootScope.language + '/PurchasesDetailsDailyReportPage.html';
            $rootScope.$watch(function () { return '../../NgApp/ReportPage/PurchasesDetailsDaily/Views/' + $rootScope.language + '/PurchasesDetailsDailyReportPage.html'; }
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
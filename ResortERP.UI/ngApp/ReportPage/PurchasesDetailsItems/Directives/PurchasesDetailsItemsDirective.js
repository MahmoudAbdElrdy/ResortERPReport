app.directive('purchasesDetailsItems', function ($rootScope, $compile) {
    return {
        restrict: 'E',
        scope: false,
        templateUrl: function (scope, element) {
            var tempurl = '../../NgApp/ReportPage/PurchasesDetailsItems/Views/' + $rootScope.language + '/PurchasesDetailsItemsReportPage.html';
            $rootScope.$watch(function () { return '../../NgApp/ReportPage/PurchasesDetailsItems/Views/' + $rootScope.language + '/PurchasesDetailsItemsReportPage.html'; }
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
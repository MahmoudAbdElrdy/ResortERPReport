app.directive('movementEntryType', function ($rootScope, $compile) {
    return {
        restrict: 'E',
        scope: false,
        templateUrl: function (scope, element) {
            var tempurl = '../../NgApp/ReportPage/MovementEntryType/Views/' + $rootScope.language + '/MovementEntryTypeReportPage.html';
            $rootScope.$watch(function () { return '../../NgApp/ReportPage/MovementEntryType/Views/' + $rootScope.language + '/MovementEntryTypeReportPage.html'; }
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
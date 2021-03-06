﻿app.directive('itemsMotion', function ($rootScope, $compile) {
    return {
        restrict: 'E',
        scope: false,
        templateUrl: function (scope, element) {
            var tempurl = '../../NgApp/ReportPage/ItemsMotion/Views/' + $rootScope.language + '/ItemsReportPage.html';
            $rootScope.$watch(function () { return '../../NgApp/ReportPage/ItemsMotion/Views/' + $rootScope.language + '/ItemsReportPage.html'; }
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
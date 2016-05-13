System.register(['./http_client_service', './target_search_service'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var http_client_service_1, target_search_service_1;
    var servicesInjectables;
    var exportedNames_1 = {
        'servicesInjectables': true
    };
    function exportStar_1(m) {
        var exports = {};
        for(var n in m) {
            if (n !== "default"&& !exportedNames_1.hasOwnProperty(n)) exports[n] = m[n];
        }
        exports_1(exports);
    }
    return {
        setters:[
            function (http_client_service_1_1) {
                http_client_service_1 = http_client_service_1_1;
                exportStar_1(http_client_service_1_1);
            },
            function (target_search_service_1_1) {
                target_search_service_1 = target_search_service_1_1;
                exportStar_1(target_search_service_1_1);
            }],
        execute: function() {
            exports_1("servicesInjectables", servicesInjectables = [
                http_client_service_1.httpClientServiceInjectables,
                target_search_service_1.targetSearchServiceInjectables,
            ]);
        }
    }
});
//# sourceMappingURL=services.js.map
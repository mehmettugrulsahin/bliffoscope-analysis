System.register(['angular2/core', '../search/target_search/target_search', './http_client_service', 'rxjs/Rx'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, target_search_1, http_client_service_1, Rx;
    var TargetSearchService, targetSearchServiceInjectables;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (target_search_1_1) {
                target_search_1 = target_search_1_1;
            },
            function (http_client_service_1_1) {
                http_client_service_1 = http_client_service_1_1;
            },
            function (Rx_1) {
                Rx = Rx_1;
            }],
        execute: function() {
            TargetSearchService = (function () {
                function TargetSearchService(httpClientService) {
                    var _this = this;
                    this.targetSearchRequestStream = new Rx.BehaviorSubject(null);
                    this.targetSearchStream = new Rx.BehaviorSubject(null);
                    this.targetSearchListStream = new Rx.BehaviorSubject(null);
                    this.targetSearchList = new Array();
                    this.targetSearchInProgressStream = new Rx.BehaviorSubject(false);
                    this.httpClientService = httpClientService;
                    var responseData;
                    this.targetSearchRequestStream
                        .filter(function (targetSearchRequest) { return targetSearchRequest != null; })
                        .subscribe(function (targetSearchRequest) {
                        _this.targetSearchInProgressStream.next(true);
                        _this.httpClientService.post("/api/searchtargets", targetSearchRequest)
                            .map(function (res) { return res.json(); })
                            .subscribe(function (data) { return responseData = data; }, function (err) { return console.log(err); }, function () {
                            var targetSearchObject = JSON.parse(JSON.stringify(responseData));
                            var targetSearch = new target_search_1.TargetSearchModel(targetSearchObject);
                            _this.targetSearchStream.next(targetSearch);
                            _this.targetSearchList.push(targetSearch);
                            _this.targetSearchListStream.next(_this.targetSearchList);
                            _this.targetSearchInProgressStream.next(false);
                        });
                    });
                }
                TargetSearchService.prototype.setTargetSearchRequest = function (targetSearchRequest) {
                    this.targetSearchRequestStream.next(targetSearchRequest);
                };
                TargetSearchService = __decorate([
                    core_1.Injectable(), 
                    __metadata('design:paramtypes', [http_client_service_1.HttpClientService])
                ], TargetSearchService);
                return TargetSearchService;
            }());
            exports_1("TargetSearchService", TargetSearchService);
            exports_1("targetSearchServiceInjectables", targetSearchServiceInjectables = [
                core_1.bind(TargetSearchService).toClass(TargetSearchService)
            ]);
        }
    }
});
//# sourceMappingURL=target_search_service.js.map
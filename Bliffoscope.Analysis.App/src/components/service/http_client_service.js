System.register(['angular2/core', 'angular2/http'], function(exports_1, context_1) {
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
    var core_1, http_1;
    var HttpClientService, httpClientServiceInjectables;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            }],
        execute: function() {
            HttpClientService = (function () {
                function HttpClientService(http) {
                    this.http = http;
                    this.baseUrl = 'http://localhost:49990';
                    this.headers = new http_1.Headers({ 'Content-Type': 'application/json' });
                    this.options = new http_1.RequestOptions({ headers: this.headers });
                }
                HttpClientService.prototype.get = function (url) {
                    return this.http.get(url, true);
                };
                HttpClientService.prototype.post = function (url, data) {
                    return this.http.post(this.baseUrl + url, JSON.stringify(data), this.options);
                };
                HttpClientService = __decorate([
                    core_1.Injectable(), 
                    __metadata('design:paramtypes', [http_1.Http])
                ], HttpClientService);
                return HttpClientService;
            }());
            exports_1("HttpClientService", HttpClientService);
            exports_1("httpClientServiceInjectables", httpClientServiceInjectables = [
                core_1.bind(HttpClientService).toClass(HttpClientService)
            ]);
        }
    }
});
//# sourceMappingURL=http_client_service.js.map
/// <reference path="../../../node_modules/angular2/ts/typings/node/node.d.ts"/>
/// <reference path="../../../node_modules/angular2/typings/browser.d.ts"/>
/// <reference path="../../../node_modules/concurrently/node_modules/rx/ts/rx.all.d.ts"/>
/// <reference path="../../../node_modules/angular2/ts/typings/jasmine/jasmine.d.ts" />
System.register(["angular2/platform/browser", "angular2/core", 'angular2/router', 'angular2/http', '../../../src/components/view/home/home_view', '../../../src/components/view/target_search/target_search_view', '../../../src/components/view/about/about_view', '../../../src/components/service/services', 'ng2-material/all'], function(exports_1, context_1) {
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
    var browser_1, core_1, router_1, http_1, home_view_1, target_search_view_1, about_view_1, services_1, all_1;
    var BliffoscopeAnalysisApp;
    return {
        setters:[
            function (browser_1_1) {
                browser_1 = browser_1_1;
            },
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (home_view_1_1) {
                home_view_1 = home_view_1_1;
            },
            function (target_search_view_1_1) {
                target_search_view_1 = target_search_view_1_1;
            },
            function (about_view_1_1) {
                about_view_1 = about_view_1_1;
            },
            function (services_1_1) {
                services_1 = services_1_1;
            },
            function (all_1_1) {
                all_1 = all_1_1;
            }],
        execute: function() {
            BliffoscopeAnalysisApp = (function () {
                function BliffoscopeAnalysisApp(sidenav) {
                    this.sidenav = sidenav;
                }
                BliffoscopeAnalysisApp.prototype.hasMedia = function (breakSize) {
                    return all_1.Media.hasMedia(breakSize);
                };
                BliffoscopeAnalysisApp.prototype.open = function (name) {
                    this.sidenav.show(name);
                };
                BliffoscopeAnalysisApp.prototype.close = function (name) {
                    this.sidenav.hide(name);
                };
                BliffoscopeAnalysisApp = __decorate([
                    core_1.Component({
                        selector: 'bliffoscope-analysis-app',
                        directives: [router_1.ROUTER_DIRECTIVES, all_1.MATERIAL_DIRECTIVES],
                        providers: [all_1.SidenavService],
                        templateUrl: './src/components/app/app.html',
                        styleUrls: ['src/components/app/app.css'],
                    }),
                    router_1.RouteConfig([
                        { path: '/', name: 'root', redirectTo: ['Home'] },
                        { path: '/home', name: 'Home', component: home_view_1.Home },
                        { path: '/targetsearchview', name: 'TargetSearchView', component: target_search_view_1.TargetSearchView },
                        { path: '/about', name: 'About', component: about_view_1.About },
                    ]), 
                    __metadata('design:paramtypes', [all_1.SidenavService])
                ], BliffoscopeAnalysisApp);
                return BliffoscopeAnalysisApp;
            }());
            browser_1.bootstrap(BliffoscopeAnalysisApp, [
                all_1.MATERIAL_PROVIDERS,
                http_1.HTTP_PROVIDERS,
                router_1.ROUTER_PROVIDERS,
                core_1.provide(router_1.LocationStrategy, { useClass: router_1.HashLocationStrategy }),
                services_1.servicesInjectables
            ]);
        }
    }
});
//# sourceMappingURL=app.js.map
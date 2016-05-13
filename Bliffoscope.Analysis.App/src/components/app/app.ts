/// <reference path="../../../node_modules/angular2/ts/typings/node/node.d.ts"/>
/// <reference path="../../../node_modules/angular2/typings/browser.d.ts"/>
/// <reference path="../../../node_modules/concurrently/node_modules/rx/ts/rx.all.d.ts"/>
/// <reference path="../../../node_modules/angular2/ts/typings/jasmine/jasmine.d.ts" />

import { bootstrap } from "angular2/platform/browser";
import { Component, provide } from "angular2/core";
import {ROUTER_PROVIDERS, ROUTER_DIRECTIVES, RouteConfig, LocationStrategy, HashLocationStrategy} from 'angular2/router';
import {HTTP_PROVIDERS, RequestOptions, BaseRequestOptions} from 'angular2/http';

import { Home } from '../../../src/components/view/home/home_view';
import { TargetSearchView } from '../../../src/components/view/target_search/target_search_view';
import { About } from '../../../src/components/view/about/about_view';

import { servicesInjectables } from '../../../src/components/service/services';

import {MATERIAL_DIRECTIVES, MATERIAL_PROVIDERS, Media, SidenavService} from 'ng2-material/all';

@Component({
  selector: 'bliffoscope-analysis-app',
  directives: [ROUTER_DIRECTIVES, MATERIAL_DIRECTIVES],
  providers: [SidenavService],
  templateUrl: './src/components/app/app.html',
  styleUrls: ['src/components/app/app.css'],
})
@RouteConfig([
  { path: '/', name: 'root', redirectTo: ['Home'] },
  { path: '/home', name: 'Home', component: Home },
  { path: '/targetsearchview', name: 'TargetSearchView', component: TargetSearchView },
  { path: '/about', name: 'About', component: About },
])
class BliffoscopeAnalysisApp {
  constructor(public sidenav: SidenavService) {
  }
  hasMedia(breakSize: string): boolean {
    return Media.hasMedia(breakSize);
  }
  open(name: string) {
    this.sidenav.show(name);
  }
  close(name: string) {
    this.sidenav.hide(name);
  }
}
bootstrap(BliffoscopeAnalysisApp, [
  MATERIAL_PROVIDERS,
  HTTP_PROVIDERS,
  ROUTER_PROVIDERS,
  provide(LocationStrategy, { useClass: HashLocationStrategy }),
  servicesInjectables
]);

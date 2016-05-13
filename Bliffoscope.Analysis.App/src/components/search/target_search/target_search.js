System.register(['angular2/core', '../starship_search/starship_search', '../slimetorpedo_search/slimetorpedo_search', '../../utility/uuid'], function(exports_1, context_1) {
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
    var core_1, starship_search_1, slimetorpedo_search_1, uuid_1;
    var TargetSearchModel, TargetSearch;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (starship_search_1_1) {
                starship_search_1 = starship_search_1_1;
            },
            function (slimetorpedo_search_1_1) {
                slimetorpedo_search_1 = slimetorpedo_search_1_1;
            },
            function (uuid_1_1) {
                uuid_1 = uuid_1_1;
            }],
        execute: function() {
            TargetSearchModel = (function () {
                function TargetSearchModel(obj) {
                    this.searchId = uuid_1.uuid(),
                        this.starshipSearch = new starship_search_1.StarshipSearchModel(obj.StarshipSearch),
                        this.slimetorpedoSearch = new slimetorpedo_search_1.SlimetorpedoSearchModel(obj.SlimetorpedoSearch),
                        this.progressMessage = obj.ProgressMessage,
                        this.progressTime = obj.ProgressTime;
                }
                return TargetSearchModel;
            }());
            exports_1("TargetSearchModel", TargetSearchModel);
            TargetSearch = (function () {
                function TargetSearch() {
                }
                TargetSearch = __decorate([
                    core_1.Component({
                        selector: 'target-search',
                        inputs: ['targetSearch'],
                        directives: [starship_search_1.StarshipSearch, slimetorpedo_search_1.SlimetorpedoSearch],
                        templateUrl: './src/components/search/target_search/target_search.html',
                        styleUrls: ['src/components/search/target_Search/target_search.css']
                    }), 
                    __metadata('design:paramtypes', [])
                ], TargetSearch);
                return TargetSearch;
            }());
            exports_1("TargetSearch", TargetSearch);
        }
    }
});
//# sourceMappingURL=target_search.js.map
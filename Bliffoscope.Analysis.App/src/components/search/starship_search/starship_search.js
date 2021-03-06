System.register(['angular2/core', '../../metadata/target/target'], function(exports_1, context_1) {
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
    var core_1, target_1;
    var StarshipSearchModel, StarshipSearch;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (target_1_1) {
                target_1 = target_1_1;
            }],
        execute: function() {
            StarshipSearchModel = (function () {
                function StarshipSearchModel(obj) {
                    var _this = this;
                    this.targetsFound = [];
                    this.targetsFoundTextImage = obj.TargetsFoundTextImage,
                        obj.TargetsFound.forEach(function (o) {
                            _this.targetsFound.push(new target_1.TargetModel(o));
                        });
                    this.targetsFoundText = '';
                    for (var _i = 0, _a = this.targetsFound; _i < _a.length; _i++) {
                        var target = _a[_i];
                        this.targetsFoundText = this.targetsFoundText + 'Type: ' + target.targetType + ', Row: ' + target.row + ', Column: ' + target.column + '\n';
                    }
                }
                return StarshipSearchModel;
            }());
            exports_1("StarshipSearchModel", StarshipSearchModel);
            StarshipSearch = (function () {
                function StarshipSearch() {
                }
                StarshipSearch = __decorate([
                    core_1.Component({
                        selector: 'starship-search',
                        inputs: ['starshipSearch'],
                        templateUrl: './src/components/search/starship_search/starship_search.html',
                        styleUrls: ['src/components/search/starship_search/starship_search.css']
                    }), 
                    __metadata('design:paramtypes', [])
                ], StarshipSearch);
                return StarshipSearch;
            }());
            exports_1("StarshipSearch", StarshipSearch);
        }
    }
});
//# sourceMappingURL=starship_search.js.map
System.register(['angular2/core', 'angular2/common'], function(exports_1, context_1) {
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
    var core_1, common_1;
    var TargetSearchForm;
    function percentageValidator(control) {
        if (isNaN(control.value)) {
            return { invalidPercentage: true };
        }
    }
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (common_1_1) {
                common_1 = common_1_1;
            }],
        execute: function() {
            TargetSearchForm = (function () {
                function TargetSearchForm(formBuilder) {
                    this.formBuilder = formBuilder;
                    this.targetSearchFormSubmit = new core_1.EventEmitter();
                }
                TargetSearchForm.prototype.ngOnInit = function () {
                    var _this = this;
                    this.targetSearchForm = this.formBuilder.group({
                        'starshipMatchPercentage': [this.targetSearchRequest.starshipMatchPercentage, common_1.Validators.compose([common_1.Validators.required, percentageValidator])],
                        'slimetorpedoMatchPercentage': [this.targetSearchRequest.slimetorpedoMatchPercentage, common_1.Validators.compose([common_1.Validators.required, percentageValidator])],
                        'bliffoscopeImage': [this.targetSearchRequest.bliffoscopeImage]
                    });
                    this.starshipMatchPercentage = this.targetSearchForm.controls['starshipMatchPercentage'];
                    this.starshipMatchPercentage.valueChanges.subscribe(function (value) { return _this.targetSearchRequest.starshipMatchPercentage = value; });
                    this.slimetorpedoMatchPercentage = this.targetSearchForm.controls['slimetorpedoMatchPercentage'];
                    this.slimetorpedoMatchPercentage.valueChanges.subscribe(function (value) { return _this.targetSearchRequest.slimetorpedoMatchPercentage = value; });
                    this.bliffoscopeImage = this.targetSearchForm.controls['bliffoscopeImage'];
                    this.bliffoscopeImage.valueChanges.subscribe(function (value) { return _this.targetSearchRequest.bliffoscopeImage = value; });
                };
                TargetSearchForm.prototype.onSubmit = function (form) {
                    this.targetSearchFormSubmit.emit(this.targetSearchRequest);
                };
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', String)
                ], TargetSearchForm.prototype, "targetSearchFormTitle", void 0);
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', String)
                ], TargetSearchForm.prototype, "targetSearchFormDescription", void 0);
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', String)
                ], TargetSearchForm.prototype, "targetSearchButtonText", void 0);
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', Object)
                ], TargetSearchForm.prototype, "targetSearchRequest", void 0);
                __decorate([
                    core_1.Output(), 
                    __metadata('design:type', core_1.EventEmitter)
                ], TargetSearchForm.prototype, "targetSearchFormSubmit", void 0);
                TargetSearchForm = __decorate([
                    core_1.Component({
                        selector: 'target-search-form',
                        directives: [common_1.FORM_DIRECTIVES],
                        templateUrl: './src/components/search/target_search_form/target_search_form.html',
                        styleUrls: ['src/components/search/target_search_form/target_search_form.css']
                    }), 
                    __metadata('design:paramtypes', [common_1.FormBuilder])
                ], TargetSearchForm);
                return TargetSearchForm;
            }());
            exports_1("TargetSearchForm", TargetSearchForm);
        }
    }
});
//# sourceMappingURL=target_search_form.js.map
System.register([], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var TargetSearchRequestModel;
    return {
        setters:[],
        execute: function() {
            TargetSearchRequestModel = (function () {
                function TargetSearchRequestModel(obj) {
                    this.starshipMatchPercentage = obj.starshipMatchPercentage;
                    this.slimetorpedoMatchPercentage = obj.slimetorpedoMatchPercentage;
                    this.bliffoscopeImage = obj.bliffoscopeImage;
                }
                return TargetSearchRequestModel;
            }());
            exports_1("TargetSearchRequestModel", TargetSearchRequestModel);
        }
    }
});
//# sourceMappingURL=target_search_request.js.map
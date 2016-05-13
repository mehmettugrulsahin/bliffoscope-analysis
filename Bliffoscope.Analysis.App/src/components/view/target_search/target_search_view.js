System.register(['angular2/core', '../../search/target_search/target_search', '../../search/target_search_request/target_search_request', '../../search/target_search_form/target_search_form', '../../service/target_search_service', '../../search/target_search_list/target_search_list'], function(exports_1, context_1) {
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
    var core_1, target_search_1, target_search_request_1, target_search_form_1, target_search_service_1, target_search_list_1;
    var TargetSearchView;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (target_search_1_1) {
                target_search_1 = target_search_1_1;
            },
            function (target_search_request_1_1) {
                target_search_request_1 = target_search_request_1_1;
            },
            function (target_search_form_1_1) {
                target_search_form_1 = target_search_form_1_1;
            },
            function (target_search_service_1_1) {
                target_search_service_1 = target_search_service_1_1;
            },
            function (target_search_list_1_1) {
                target_search_list_1 = target_search_list_1_1;
            }],
        execute: function() {
            TargetSearchView = (function () {
                function TargetSearchView(targetSearchService) {
                    var _this = this;
                    this.targetSearchFormTitle = 'Bliffoscope Data Analysis';
                    this.targetSearchFormDescription = 'Analyzes arbitrary-sized Bliffoscope images, returning a list of slime torpedo and starhip targets.';
                    this.targetSearchButtonText = 'Analyze Bliffoscope image';
                    this.bliffoscopeImage = '              + +    +              ++           +       +++    +     +               +    +    +   \n\
 +  ++     +   + ++++    + +       +         +          +  +   +++     +++ +           + + +      + \n\
     +            + +   ++      ++  ++    + ++       +     +      +  +   +      ++   ++       +     \n\
+   ++      +  ++       +          + +       ++        ++  +           +                  +         \n\
 ++++++ + +    +   ++  +  +   +   +  ++      +         +                     +     ++      +     + +\n\
  + +   +      +               +      ++     +  ++            +   +    + +     +     +   +  + +     \n\
+++   + ++   +  +            +  +++       + +       ++                     +            +  + +  +   \n\
  +++++  +      +                            +  + +            +   +  +        +   +             +  \n\
 +   +   +              +    +      +            +  +   +      +    +     +    +   +                \n\
 ++    +              +     +       ++   +          +       +           ++       +          + +     \n\
  ++++ +        + +  +    ++ +       +                      +                    +     +         + +\n\
+   ++  +     +      +  +  +  +    + + ++            + +   + + +    +      +   +++   ++   +     +  +\n\
+  ++  +              +   ++   ++       +      + +++++            +    +    ++    +++  +    +    + +\n\
 +  + +     +  + +   +           ++  ++ +  +                 + ++                           +++  +  \n\
 +        +              +                ++    +    + +     + ++     ++ + +  + +   +            +++\n\
 +    + ++  +   + + +     +  + ++ +   + + +    +     +  + +++  +                       +          + \n\
         +   ++ + + ++    +   +  ++ ++ +      +     +      ++   +   +     +     ++  +   + +     ++  \n\
   +  +            + +     ++ +   +  ++++ ++            +  +  +    +     +      +        +  +  +    \n\
+    +   ++++       + ++ +      ++ +                           + +      +++ +       ++ +            \n\
 +               +     +   + ++ +   ++   +     +            + +  +  ++  +                 +  +      \n\
 +      +              +       + ++ + +  +       + +     +  ++    +          +      + +   +++       \n\
         +  +    ++ +     +   +++ ++  +++                        +     +      ++     +  +    ++    +\n\
 +   +       + +         ++    + ++  ++      +  +++     ++ +  + +  +      +                 +   +   \n\
+    +    +         + + ++  + + + + ++  + +           +  + ++     +               +            +    \n\
+   ++        +  +             ++ ++ +++        +    ++        +  +   +    +         ++  +  +       \n\
         +  ++ +   ++       +   + +   + ++   ++ +    +     +            +                    +   ++ \n\
 + +    ++ ++   +      +       +            +   +       +++ ++++++    ++             + +  +       + \n\
    + +  + +         +       ++    +     +     +  +     +       +  +      +  +++    +         ++    \n\
    +           ++   +  +          ++  +    ++         ++  +  ++++++            + +  +        +    +\n\
  +  + ++    +     +     + +       +     +           +    +  ++       + +    ++     ++   +          \n\
 +  +     + + ++    +       +    +++     + ++ +     ++++     ++  +   +  +       ++     +           +\n\
    ++ +     +         +       +  +       +   +  ++   +       +                   +                +\n\
      +                 +                  +      +      +++++  ++++        + +       +++  +  ++   +\n\
  +       +++++   +   +    +  +   +    + +   + +        +++    +  +        +    +      + + +    + + \n\
 +    ++       +   + +       ++      +  +   + +        +++++  + +++++++ ++ +     ++     +           \n\
  ++++        +    +         +  +  +     + +   +++      +        ++ +  ++   + +        + + ++       \n\
     +  +  +   +         +     +     +      + +             +     + + ++++ +    ++      ++       +  \n\
 +               +       +      +          +                +    +    ++   ++             + + + ++  \n\
  +     +   + +      +      +          ++           +   ++       ++++             + +       ++      \n\
      ++    +  +         ++  +  +    +  +                +    + + + +  + +  +    +  +     + +    +  \n\
 +            +   +     ++            + +   +   +       +   +      ++ ++  ++ +        +   ++     +  \n\
 +    +      +  + ++ + +              +   +           +   +    + ++    +          ++   +           +\n\
 + + +  +  ++ +  ++   +     +  + +                    +      +    + ++++++++  +  ++         ++   ++ \n\
  +   +  +   + +        ++          ++      +      +      ++  +         +      + ++    +  ++  +  +  \n\
 +  +  ++    +      ++   ++  +    +       +       +      ++             +         +    +   +      ++\n\
                 +  +++    +++          +     ++  +    +        +  +       +                   ++   \n\
  ++                  +   + +   +++     ++        +    +  +              ++   ++      +             \n\
  + ++ +       +             + +   ++                        +      ++    +  +   +            + +   \n\
+       +     + ++        +   +     +      +          +     ++     + +++    +    +        ++       +\n\
    +    +     + + +       +   +        +         +        +         + +    +         +  +   ++     \n\
   +    +               ++  + +     +    +++   + +  ++     +    + + ++     +          +     +    ++ \n\
         +  +      +  + + +      +        +      +  +  +             + + +  +   + ++  +             \n\
 +            +       ++    +  +      ++       +     +     +      +  +        ++ + ++          + + +\n\
    ++++      +   +  +   +        ++       +              +  + + ++      + +  ++   +  +     +     ++\n\
+     + +   +     +++   +     +     +    + +                             +    +  +  ++   +   +      \n\
   +  + ++      + + +      + +        +   +     +     +   +       +   +            +  +             \n\
 +    +         +    +       + + +++            +   +  ++ +  + ++   +   +          +      ++   ++ + \n\
    ++ ++             +   ++         +   + +       +++ +             +      +  + +  +  +       +    \n\
 +  ++   ++             +        ++         + + +  +   + + +++   +               +    +     +      +\n\
    +    +       +         +          +        + +   ++   +        ++           +       + ++   +    \n\
+         + +  ++  ++    +    + ++     +   ++  +     ++  +                     + + + +   +   +      \n\
+             +         + ++     + +  +  + +         +    +           +      + +     +  + + + +   + \n\
               +    ++   +++    + +         +  +  +                +    +  +    + ++   +  +   +  +  \n\
 ++    +           ++   +   +            + ++ ++               + +              +     +    +   +    \n\
  +    + +    +       +    +  + +++       +         +                 ++    +++   +   + ++          \n\
            + +  +   +  +       +        +       +    +  + ++ ++              + +   +        +      \n\
+  +         +       +    +   +       +   +          +    ++ +      ++            +           +     \n\
           +  +++        +     +    + +        +  +             +          + +                +     \n\
 ++++  +  +       +  +++  ++ +     + ++         ++ + +        +  +  +     + +       ++++          + \n\
    +   ++ +                ++++  +  +  +   ++  + +   +     + +  +          +      +   ++  ++       \n\
 +               +   ++  ++       +         +++++ ++ ++    + ++      ++     +   +      +   +   +    \n\
 +         +  +    +                   +  +      ++     + + +   +  ++              + +    +++ + +   \n\
              + ++ ++  + +    +                + ++ +                 ++ +++          +     +       \n\
+                   +   +      ++ +         +    + +        +             +        +   +        +  +\n\
  +    +          ++         +       +   + +    +++  + ++  + +  ++  +   +          +++ +  +       ++\n\
     +        +   +     +                  +++     + ++               +     +  +    +     + +       \n\
  +    +       +     +         +    +   +     +  ++ +++    +   ++            ++  +          ++     +\n\
   +  +   +   + +   +     +  +   +    +                     +  + +         +++ +   +    +           \n\
    +   +    + +       +   + +      +    +        +   +++   +  ++        +     + + +  +    ++   ++  \n\
    +    +    +   +         + +     + +    +++   +  +      +   +       +++    + + +  +         ++   \n\
    +   +   +         +  +    +    +   +     +            +   + +   +     +     +             +     \n\
 +      + +++   + + ++  + ++  ++         +      + +  + ++  +            +  +     +    ++ +   + + + +\n\
 +  ++       +           +++ + +  +              +            + +                  ++        +   +  \n\
                      + +  ++ + +        +++    + + +     ++ ++      +   ++ +     +   +       +    +\n\
     +  +              +  ++  +    +               + + +      +    +   ++ ++      ++     ++   +     \n\
  +  + + +         +      +++++  ++    +  +       + + +               +      + +            +     + \n\
    ++  +   +  +          +++ +  ++   +    +    +       +    +    + ++  +  ++    +   +   +     +    \n\
       +      + +   + ++++ ++       + +  +  +    +    ++     +          + +++  ++               +   \n\
 +       +   +      +  + +++++ + +      +   +   ++  +    +      + +      +++    +             ++    \n\
+ +       +    +   +       + + +           +      +        +  +++  +         +          +      ++   \n\
         +            +    ++  ++++ + +           +          + +   +  +   ++       + + +      +     \n\
             + ++  ++    ++     +     +           ++    +        ++                  ++ +           \n\
                     + +          +      + +  +      +    +   +   +  +    +     +    +   +  +   + + \n\
    +     ++   ++   +  +      + +          +     + +    +       +   +   ++ +    +        + +    ++  \n\
+                 +          ++       +             +     + +      + +       +  +   +  +     +  ++  \n\
       + +       + +     +  +    +  +  ++      +       ++   +                           ++ +   +    \n\
             +  + ++      +  +    +      ++ + +                        +    + +    +    ++          \n\
          +        +   +                    +         +     + +  + +             +   +  +           \n\
  +     +       + +     ++   +        +++   +    +       +   + + +       +            +     ++   ++ \n\
        ++  +   +      +  +    +++  +  ++                  ++ + +   +                + +     +  +  +';
                    this.targetSearchRequest = new target_search_request_1.TargetSearchRequestModel({
                        starshipMatchPercentage: '35',
                        slimetorpedoMatchPercentage: '35',
                        bliffoscopeImage: this.bliffoscopeImage });
                    this.targetSearchService = targetSearchService;
                    this.targetSearchService.targetSearchInProgressStream
                        .subscribe(function (targetSearchInProgress) {
                        _this.targetSearchInProgress = targetSearchInProgress;
                    });
                    this.targetSearchService.targetSearchStream
                        .subscribe(function (targetSearch) {
                        _this.targetSearch = targetSearch;
                    });
                    this.targetSearchService.targetSearchListStream
                        .subscribe(function (targetSearchList) {
                        _this.targetSearchList = targetSearchList;
                    });
                }
                TargetSearchView.prototype.onTargetSearchFormSubmit = function (newTargetSearchRequest) {
                    this.targetSearchRequest = newTargetSearchRequest;
                    this.targetSearchService.setTargetSearchRequest(this.targetSearchRequest);
                };
                TargetSearchView = __decorate([
                    core_1.Component({
                        selector: 'target-search-view',
                        directives: [target_search_form_1.TargetSearchForm, target_search_1.TargetSearch, target_search_list_1.TargetSearchList],
                        templateUrl: './src/components/view/target_search/target_search_view.html',
                        styleUrls: ['src/components/view/target_search/target_search_view.css']
                    }), 
                    __metadata('design:paramtypes', [target_search_service_1.TargetSearchService])
                ], TargetSearchView);
                return TargetSearchView;
            }());
            exports_1("TargetSearchView", TargetSearchView);
        }
    }
});
//# sourceMappingURL=target_search_view.js.map
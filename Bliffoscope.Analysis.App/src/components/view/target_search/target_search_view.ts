import { Component } from 'angular2/core';

import { TargetSearch, TargetSearchModel } from '../../search/target_search/target_search';
import { ITargetSearchRequestModel, TargetSearchRequestModel } from '../../search/target_search_request/target_search_request';
import { TargetSearchForm } from '../../search/target_search_form/target_search_form';
import { TargetSearchService } from '../../service/target_search_service';
import { TargetSearchList } from '../../search/target_search_list/target_search_list';

@Component({
  selector: 'target-search-view',
  directives: [TargetSearchForm, TargetSearch, TargetSearchList],
  templateUrl: './src/components/view/target_search/target_search_view.html',
  styleUrls: ['src/components/view/target_search/target_search_view.css']
})
export class TargetSearchView {
  targetSearchFormTitle: string = 'Bliffoscope Data Analysis';
  targetSearchFormDescription: string = 'Analyzes arbitrary-sized Bliffoscope images, returning a list of slime torpedo and starhip targets.';
  targetSearchButtonText: string = 'Analyze Bliffoscope image';
  targetSearchRequest: ITargetSearchRequestModel;
  targetSearchService: TargetSearchService;
  targetSearch: TargetSearchModel;
  targetSearchList: TargetSearchModel[];
  targetSearchInProgress: boolean;
  bliffoscopeImage: string =
'              + +    +              ++           +       +++    +     +               +    +    +   \n\
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

  constructor(targetSearchService: TargetSearchService) {
    this.targetSearchRequest = new TargetSearchRequestModel({
      starshipMatchPercentage: '35',
      slimetorpedoMatchPercentage: '35',
      bliffoscopeImage: this.bliffoscopeImage});

    this.targetSearchService = targetSearchService;

    this.targetSearchService.targetSearchInProgressStream
    .subscribe((targetSearchInProgress: boolean) => {
      this.targetSearchInProgress = targetSearchInProgress
    });

    this.targetSearchService.targetSearchStream
    .subscribe((targetSearch: TargetSearchModel) => {
      this.targetSearch = targetSearch
    });

    this.targetSearchService.targetSearchListStream
    .subscribe((targetSearchList: TargetSearchModel[]) => {
      this.targetSearchList = targetSearchList
    });
  }

  onTargetSearchFormSubmit(newTargetSearchRequest: ITargetSearchRequestModel) {
    this.targetSearchRequest = newTargetSearchRequest;
    this.targetSearchService.setTargetSearchRequest(this.targetSearchRequest);
  }
}

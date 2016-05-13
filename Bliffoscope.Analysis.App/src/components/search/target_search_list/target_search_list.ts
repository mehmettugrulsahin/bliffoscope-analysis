import { Component } from 'angular2/core';
import { TargetSearchModel } from '../target_search/target_search';

@Component({
  selector: 'target-search-list',
  inputs: ['targetSearchList'],
  templateUrl: './src/components/search/target_search_list/target_search_list.html',
  styleUrls: ['./src/components/search/target_search_list/target_search_list.css']
})
export class TargetSearchList {
  targetSearchList: TargetSearchModel[];
}

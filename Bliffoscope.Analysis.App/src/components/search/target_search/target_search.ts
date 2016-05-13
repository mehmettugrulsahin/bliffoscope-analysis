import { Component } from 'angular2/core';
import { NgSwitch } from 'angular2/common';
import { StarshipSearch, StarshipSearchModel } from '../starship_search/starship_search';
import { SlimetorpedoSearch, SlimetorpedoSearchModel } from '../slimetorpedo_search/slimetorpedo_search';
import { uuid } from '../../utility/uuid';

export class TargetSearchModel {
  searchId: string;
  starshipSearch: StarshipSearchModel;
  slimetorpedoSearch: SlimetorpedoSearchModel;
  progressMessage: string;
  progressTime: string;

  constructor(obj?: any) {
    this.searchId = uuid(),
    this.starshipSearch = new StarshipSearchModel(obj.StarshipSearch),
    this.slimetorpedoSearch = new SlimetorpedoSearchModel(obj.SlimetorpedoSearch),
    this.progressMessage = obj.ProgressMessage,
    this.progressTime = obj.ProgressTime
  }
}

@Component({
  selector: 'target-search',
  inputs: ['targetSearch'],
  directives: [StarshipSearch, SlimetorpedoSearch],
  templateUrl: './src/components/search/target_search/target_search.html',
  styleUrls: ['src/components/search/target_Search/target_search.css']
})
export class TargetSearch {
  targetSearch: TargetSearchModel;
}

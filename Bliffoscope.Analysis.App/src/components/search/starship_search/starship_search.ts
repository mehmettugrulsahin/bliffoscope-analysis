import { Component } from 'angular2/core';
import { NgFor } from 'angular2/common';
import {Target, TargetModel } from '../../metadata/target/target';

export class StarshipSearchModel {
  targetsFoundTextImage: string;
  targetsFound: TargetModel[] = [];
  targetsFoundText: string;

  constructor(obj?: any) {
    this.targetsFoundTextImage = obj.TargetsFoundTextImage,

    obj.TargetsFound.forEach(o => {
      this.targetsFound.push(new TargetModel(o));
    });

    this.targetsFoundText = '';
    for (let target of this.targetsFound) {
      this.targetsFoundText = this.targetsFoundText + 'Type: ' + target.targetType + ', Row: ' + target.row + ', Column: ' + target.column + '\n';
    }
  }
}

@Component({
  selector: 'starship-search',
  inputs: ['starshipSearch'],
  templateUrl: './src/components/search/starship_search/starship_search.html',
  styleUrls: ['src/components/search/starship_search/starship_search.css']
})
export class StarshipSearch {
  starshipSearch: StarshipSearchModel;
}

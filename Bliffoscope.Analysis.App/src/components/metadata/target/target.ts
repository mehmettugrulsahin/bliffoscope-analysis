import { Component } from 'angular2/core';

export class TargetModel {
  targetType: string;
  row: number;
  column: number;

  constructor(obj?: any) {
    this.targetType = obj.TargetType;
    this.row = obj.Row;
    this.column = obj.Column;
  }
}

@Component({
  selector: 'target',
  inputs: ['Target'],
  templateUrl: './src/components/metadata/target/target.html',
  styleUrls: ['src/components/metadata/target/target.css']
})
export class Target {
  target: TargetModel;
}

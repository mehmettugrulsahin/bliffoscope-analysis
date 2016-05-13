export interface ITargetSearchRequestModel {
  starshipMatchPercentage: string;
  slimetorpedoMatchPercentage: string;
  bliffoscopeImage: string;
}

export class TargetSearchRequestModel implements ITargetSearchRequestModel {
  starshipMatchPercentage: string;
  slimetorpedoMatchPercentage: string;
  bliffoscopeImage: string;

  constructor(obj?: any) {
    this.starshipMatchPercentage = obj.starshipMatchPercentage;
    this.slimetorpedoMatchPercentage = obj.slimetorpedoMatchPercentage;
    this.bliffoscopeImage = obj.bliffoscopeImage;
  }
}

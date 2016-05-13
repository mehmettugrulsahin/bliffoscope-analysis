import { Component, Input, OnInit, Output, EventEmitter } from 'angular2/core';
import { CORE_DIRECTIVES, FORM_DIRECTIVES, FormBuilder, ControlGroup, Validators, AbstractControl, Control } from 'angular2/common';
import { ITargetSearchRequestModel } from '../target_search_request/target_search_request';

function percentageValidator(control: Control): { [s: string]: boolean } {
  if (isNaN(control.value)) {
    return {invalidPercentage: true};
  }
}

@Component({
  selector: 'target-search-form',
  directives: [FORM_DIRECTIVES],
  templateUrl: './src/components/search/target_search_form/target_search_form.html',
  styleUrls: ['src/components/search/target_search_form/target_search_form.css']
})
export class TargetSearchForm implements OnInit {
  @Input() targetSearchFormTitle: string;
  @Input() targetSearchFormDescription: string;
  @Input() targetSearchButtonText: string;
  @Input() targetSearchRequest: ITargetSearchRequestModel;
  @Output() targetSearchFormSubmit: EventEmitter<ITargetSearchRequestModel>;

  formBuilder: FormBuilder;

  targetSearchForm: ControlGroup;
  starshipMatchPercentage: AbstractControl;
  slimetorpedoMatchPercentage: AbstractControl;
  bliffoscopeImage: AbstractControl;

  constructor(formBuilder: FormBuilder) {
    this.formBuilder = formBuilder;
    this.targetSearchFormSubmit = new EventEmitter<ITargetSearchRequestModel>();
  }

  ngOnInit(): void {
    this.targetSearchForm = this.formBuilder.group({
      'starshipMatchPercentage': [this.targetSearchRequest.starshipMatchPercentage, Validators.compose([Validators.required, percentageValidator])],
      'slimetorpedoMatchPercentage': [this.targetSearchRequest.slimetorpedoMatchPercentage, Validators.compose([Validators.required, percentageValidator])],
      'bliffoscopeImage': [this.targetSearchRequest.bliffoscopeImage]
    });

    this.starshipMatchPercentage = this.targetSearchForm.controls['starshipMatchPercentage'];
    this.starshipMatchPercentage.valueChanges.subscribe((value: string) => this.targetSearchRequest.starshipMatchPercentage = value);

    this.slimetorpedoMatchPercentage = this.targetSearchForm.controls['slimetorpedoMatchPercentage'];
    this.slimetorpedoMatchPercentage.valueChanges.subscribe((value: string) => this.targetSearchRequest.slimetorpedoMatchPercentage = value);

    this.bliffoscopeImage = this.targetSearchForm.controls['bliffoscopeImage'];
    this.bliffoscopeImage.valueChanges.subscribe((value: string) => this.targetSearchRequest.bliffoscopeImage = value);
  }

  onSubmit(form: any): void {
    this.targetSearchFormSubmit.emit(this.targetSearchRequest);
  }
}

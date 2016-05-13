import { Injectable, bind } from 'angular2/core';
import { TargetSearchModel } from '../search/target_search/target_search';
import { HttpClientService } from './http_client_service';
import * as Rx from 'rxjs/Rx';
import { ITargetSearchRequestModel } from '../search/target_search_request/target_search_request';

@Injectable()
export class TargetSearchService {
  targetSearchRequestStream: Rx.Subject<ITargetSearchRequestModel> = new Rx.BehaviorSubject<ITargetSearchRequestModel>(null);
  targetSearchStream: Rx.Subject<TargetSearchModel> = new Rx.BehaviorSubject<TargetSearchModel>(null);
  targetSearchListStream: Rx.Subject<TargetSearchModel[]> = new Rx.BehaviorSubject<TargetSearchModel[]>(null);
  targetSearchList: TargetSearchModel[] = new Array<TargetSearchModel>();
  targetSearchInProgressStream: Rx.Subject<boolean> = new Rx.BehaviorSubject<boolean>(false);

  httpClientService: HttpClientService;

  constructor(httpClientService: HttpClientService) {
    this.httpClientService = httpClientService;
    let responseData: JSON;

    this.targetSearchRequestStream
    .filter(targetSearchRequest => targetSearchRequest != null)
    .subscribe((targetSearchRequest: ITargetSearchRequestModel) => {
      this.targetSearchInProgressStream.next(true);
      this.httpClientService.post("/api/searchtargets", targetSearchRequest)
      .map(res => res.json())
      .subscribe(
        data => responseData = data,
        err => console.log(err),
        () => {
          let targetSearchObject = <TargetSearchModel>JSON.parse(JSON.stringify(responseData));
          let targetSearch: TargetSearchModel = new TargetSearchModel(targetSearchObject);
          this.targetSearchStream.next(targetSearch);

          this.targetSearchList.push(targetSearch);
          this.targetSearchListStream.next(this.targetSearchList);

          this.targetSearchInProgressStream.next(false);
        }
      );
    })
  }

  setTargetSearchRequest(targetSearchRequest: ITargetSearchRequestModel) {
    this.targetSearchRequestStream.next(targetSearchRequest);
  }
}

export var targetSearchServiceInjectables: Array<any> = [
  bind(TargetSearchService).toClass(TargetSearchService)
];

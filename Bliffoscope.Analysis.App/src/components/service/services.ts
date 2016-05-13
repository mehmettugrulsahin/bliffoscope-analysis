import { httpClientServiceInjectables } from './http_client_service';
import { targetSearchServiceInjectables } from './target_search_service';

export * from './http_client_service';
export * from './target_search_service';

export var servicesInjectables: Array<any> = [
  httpClientServiceInjectables,
  targetSearchServiceInjectables,
];

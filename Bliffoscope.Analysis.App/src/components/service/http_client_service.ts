import { Injectable, bind } from 'angular2/core';
import { Http, RequestOptions, Response, Headers } from 'angular2/http';

@Injectable()
export class HttpClientService {
  http: Http;
  baseUrl: string;
  responseData: JSON;
  headers: Headers;
  options: RequestOptions;

  constructor(http: Http) {
    this.http = http;
    this.baseUrl = 'http://localhost:49990';
    this.headers = new Headers({ 'Content-Type': 'application/json' });
    this.options = new RequestOptions({ headers: this.headers });
  }

  get(url) {
    return this.http.get(url, true);
  }

  post(url, data) {
    return this.http.post(this.baseUrl + url, JSON.stringify(data), this.options);
  }
}

export var httpClientServiceInjectables: Array<any> = [
  bind(HttpClientService).toClass(HttpClientService)
];

import { Inject, Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpClientService {

  constructor(private HttpClient: HttpClient, @Inject("baseUrl")private baseUrl: string) { }

  

  private url(requestParameter: Partial<RequestParameters>): string {
    return `${requestParameter.baseUrl ? requestParameter.baseUrl : this.baseUrl}/${requestParameter.controller}${requestParameter.action ? `/${requestParameter.action}` : ""}`;
  }
    

  get<T>(requestParameter : Partial<RequestParameters>, id?: string): Observable<T> {

    let url: string = "";
    if (requestParameter.fullEndPoint)
      url = requestParameter.fullEndPoint;
    else
      url = `${this.url(requestParameter)}${id ? `/${id}` : ""}${requestParameter.queryString ? `?${requestParameter.queryString}` :""}`;

    return this.HttpClient.get<T>(url, { headers: requestParameter.headers });
  }

  Post<T>(requestParameter : Partial<RequestParameters>, body: Partial<T>):Observable<T> {
    let url: string = "";
    if (requestParameter.fullEndPoint)
      url = requestParameter.fullEndPoint;
    else
      url = `${this.url(requestParameter)}${requestParameter.queryString ? `?${requestParameter.queryString}` :""}`;

    return this.HttpClient.post<T>(url, body, { headers: requestParameter.headers });

  }

  Put<T>(requestParameter:Partial<RequestParameters>, body: Partial<T>){
    let url: string = "";
    if (requestParameter.fullEndPoint)
      url = requestParameter.fullEndPoint;
    else
      url = `${this.url(requestParameter)}${requestParameter.queryString ? `?${requestParameter.queryString}` :""}`;

      return this.HttpClient.put<T>(url,body,{headers:requestParameter.headers})


  }

  Delete<T>(requestParameter:Partial<RequestParameters>,id:string){
    let url: string = "";
    if (requestParameter.fullEndPoint)
      url = requestParameter.fullEndPoint;
    else
      url = `${this.url(requestParameter)}/${id}${requestParameter.queryString ? `?${requestParameter.queryString}` :""}`;

      return this.HttpClient.delete<T>(url,{headers:requestParameter.headers});

  }
}

export class RequestParameters{
  controller ?: string;
  action ?: string;
  queryString ?: string;

  headers ?: HttpHeaders;
  baseUrl ?: string;
  fullEndPoint ?: string;



}



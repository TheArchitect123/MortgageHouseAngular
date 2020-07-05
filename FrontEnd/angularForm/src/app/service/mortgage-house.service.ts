//Http Client Handlers
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SecurityConstants } from '../Constants/SecurityConstants';
//Local resources
import { UrlResources } from '../Constants/UrlResources';

@Injectable({
  providedIn: 'root',
})
export class MortgageHouseService {
  constructor(private http: HttpClient) {}
  PostInformation(json: string): Observable<boolean> {
    let headers = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        xUsername: SecurityConstants.xUsername,
        xPassword: SecurityConstants.xPassword,
      }),
    };

    //Send the information to the remote server
    return this.http.post<boolean>(UrlResources.CommonPostEndpoint, json);
  }
}

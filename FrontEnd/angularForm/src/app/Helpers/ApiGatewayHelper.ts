import { HttpClient } from '@angular/common/http'; //Will be used for sending the data off to the
import { Injectable } from '@angular/core';
import { MortgageHouseService } from '../service/mortgage-house.service';
import { Observable } from 'rxjs';
import { UrlResources } from '../Constants/UrlResources';

@Injectable({
  // we declare that this service should be created
  // by the root application injector.
  providedIn: 'root',
})
export class ApiGatewayHelper {
  constructor(private mcservice: MortgageHouseService) {}
  public SendInfoToRemoteServer(json: string): Observable<any> {
    //invoke the http client api, to send the details off
    return this.mcservice.PostInformation(json);
  }
}

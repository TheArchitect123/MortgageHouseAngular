import { HttpClient } from '@angular/common/http'; //Will be used for sending the data off to the
import { Injectable } from '@angular/core';
import { MortgageHouseService } from '../service/mortgage-house.service';
import { UrlResources } from '../Constants/UrlResources';

export class ApiGatewayHelper {
  constructor(private mcservice: MortgageHouseService) {}
  public async SendInfoToRemoteServer(json: string): Promise<boolean> {
    //invoke the http client api, to send the details off
    this.mcservice.PostInformation(json);
    return true;
  }
}

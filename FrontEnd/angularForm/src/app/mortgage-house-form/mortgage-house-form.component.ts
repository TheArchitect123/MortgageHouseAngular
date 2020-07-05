import { Component, ɵbypassSanitizationTrustResourceUrl } from '@angular/core';

import { ApiGatewayHelper } from '../Helpers/ApiGatewayHelper';
import { HttpClientModule } from '@angular/common/http'; //Will be used for sending the data off to the
import { StreetType } from '../enums/streetType';
import { UnionDetails } from '../models/unionDetails';

//Models
@Component({
  selector: 'mortgage-house-form',
  templateUrl: './mortgage-house-form.component.html',
  styleUrls: ['./mortgage-house-form.component.css'],
})
export class MortgageFormComponent {
  constructor(private gateway: ApiGatewayHelper) {}

  isSubmissionEnabled(): boolean {
    var result: boolean = true;
    if (!this.dtoObj.contactDto.DateOfBirth) result = false;
    if (!this.dtoObj.contactDto.FirstName) result = false;
    if (!this.dtoObj.contactDto.LastName) result = false;
    if (!this.dtoObj.contactDto.PhoneNumber) result = false;
    if (!this.dtoObj.addressDto.StreetName) result = false;
    if (!this.dtoObj.addressDto.StreetNumber) result = false;
    if (!this.dtoObj.addressDto.Suburb) result = false;

    result = this.dtoObj.addressDto.StreetOption != null;
    result = this.dtoObj.addressDto.Postcode != null;

    return result;
  }

  //Data Binding
  dtoObj: UnionDetails;
  streetOptions = ['Street', 'Avenue', 'Court'];

  async submitFormToServer() {
    if (this.isSubmissionEnabled()) {
      //Make sure to disable the submission button when the the controls are still missing some details
      let jsonDetails = JSON.stringify(this.dtoObj);
      if (jsonDetails != null && jsonDetails.startsWith('[]')) {
        //If the string looks good to parse, then send it over to the server
        //generate a post function, to send the data off to the server
        await this.gateway.SendInfoToRemoteServer(jsonDetails);
      }
    } else {
      alert('Cannot submit the form details to the server');
    }

    return true;
  }
}

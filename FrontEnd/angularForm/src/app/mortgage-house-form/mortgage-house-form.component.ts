import {
  Component,
  OnInit,
  ɵbypassSanitizationTrustResourceUrl,
} from '@angular/core';

import { AddressDto } from '../models/address';
import { ApiGatewayHelper } from '../Helpers/ApiGatewayHelper';
import { ContactAddressDto } from '../models/unionDetails';
import { ContactDto } from '../models/contact';
import { HttpClientModule } from '@angular/common/http'; //Will be used for sending the data off to the
import { StreetType } from '../enums/streetType';
//Helpers
import { StringHelper } from '../Helpers/StringHelper';

//Models
@Component({
  selector: 'mortgage-house-form',
  templateUrl: './mortgage-house-form.component.html',
  styleUrls: ['./mortgage-house-form.component.css'],
})
export class MortgageFormComponent implements OnInit {
  constructor(private gateway: ApiGatewayHelper) {}
  ngOnInit(): void {
    //Initialize the model -- for processing
    this.initializeModel();
  }

  isSubmissionEnabled(): boolean {
    var result: boolean = true;

    // result = StringHelper.existValueInEnum(
    //   typeof StreetType,
    //   this.dtoObj.AddressItem.StreetOption
    // );

    result = this.dtoObj.AddressItem.StreetOption != null;
    result = Number.isInteger(this.dtoObj.AddressItem.Postcode);

    if (StringHelper.isEmpty(this.dtoObj.ContactItem.DateOfBirth))
      result = false;

    if (StringHelper.isEmpty(this.dtoObj.ContactItem.FirstName)) {
      result = false;
    }
    if (StringHelper.isEmpty(this.dtoObj.ContactItem.LastName)) {
      result = false;
    }
    if (StringHelper.isEmpty(this.dtoObj.ContactItem.PhoneNumber)) {
      result = false;
    }
    if (StringHelper.isEmpty(this.dtoObj.AddressItem.StreetName)) {
      result = false;
    }
    if (StringHelper.isEmpty(this.dtoObj.AddressItem.StreetNumber)) {
      result = false;
    }
    if (StringHelper.isEmpty(this.dtoObj.AddressItem.Suburb)) {
      result = false;
    }

    return result;
  }

  resetFormData() {
    this.dtoObj.AddressItem.StreetOption = StreetType.Street;
    this.dtoObj.AddressItem.Postcode = null;
    this.dtoObj.AddressItem.StreetName = '';
    this.dtoObj.AddressItem.StreetNumber = '';
    this.dtoObj.AddressItem.Suburb = '';

    this.dtoObj.ContactItem.DateOfBirth = '';
    this.dtoObj.ContactItem.FirstName = '';
    this.dtoObj.ContactItem.LastName = '';
    this.dtoObj.ContactItem.MiddleName = '';
    this.dtoObj.ContactItem.PhoneNumber = '';
  }

  initializeModel() {
    if (this.dtoObj == null) this.dtoObj = new ContactAddressDto();
    if (this.dtoObj.ContactItem == null)
      this.dtoObj.ContactItem = new ContactDto();

    if (this.dtoObj.AddressItem == null)
      this.dtoObj.AddressItem = new AddressDto();
  }

  //Data Binding
  dtoObj: ContactAddressDto;
  streetOptions = ['Street', 'Avenue', 'Court'];

  async submitFormToServer() {
    if (this.isSubmissionEnabled()) {
      //Make sure to disable the submission button when the the controls are still missing some details
      //If the string looks good to parse, then send it over to the server
      //generate a post function, to send the data off to the server
      //alert(JSON.stringify(this.dtoObj));
      this.gateway
        .SendInfoToRemoteServer(JSON.stringify(this.dtoObj))
        .subscribe((e: boolean) => {
          if (e)
            alert('Successfuly submitted form (contact & address details)');
          else alert('Failed to send account information to the server');
        });
      //Force a reset once the item is successfully
    } else {
      alert(
        'Cannot submit the form details to the server. Please fill out all the fields before resubmitting'
      );
    }

    return true;
  }
}

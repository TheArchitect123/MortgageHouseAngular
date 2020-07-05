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

    //Check the regular expressions
    result = !this.checkPostCodeRule(); //Validate Postcode
    result = !this.checkContactFirstNameRule(); //Validate First Name
    result = !this.checkContactMiddleNameRule(); //Validate Middle Name
    result = !this.checkContactLastNameRule(); //Validate Last Name
    result = !this.checkPhoneNumberRule(); // Validate Phone Number
    result = !this.checkStreetNumberRule(); // Validate Street Number

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

  //Regular Expression Rules -- For Validating Forms
  regex_postcode: RegExp = new RegExp('^[0-9]{4}$');
  regex_phoneNumber: RegExp = new RegExp('/^[0-9]{10}$/');
  regex_streetNumber: RegExp = new RegExp('/^[a-zA-Z]^[0-9]{1}$/');
  regex_contactName: RegExp = new RegExp('/^[a-zA-Z]{3,}$/');

  //Show the Error Divs
  hasPostcodeEntryError: boolean = false;
  hasPhoneNumberEntryError: boolean = false;
  hasStreetNumberEntryError: boolean = false;
  hasContactFirstNameEntryError: boolean = false;
  hasContactMiddleNameEntryError: boolean = false;
  hasContactLastNameEntryError: boolean = false;

  //Using the Above Regular expressions, these functions will be used to make sure that each field entry is abiding by the rules
  //stated in the business requirements
  checkPostCodeRule(): boolean {
    if (!this.regex_postcode.test(`${this.dtoObj.AddressItem.Postcode}`)) {
      //If the condition fails
      return (this.hasPostcodeEntryError = true);
    } else return (this.hasPostcodeEntryError = false);
  }

  checkPhoneNumberRule(): boolean {
    if (
      !this.regex_phoneNumber.test(`${this.dtoObj.ContactItem.PhoneNumber}`)
    ) {
      //If the condition fails
      return (this.hasPhoneNumberEntryError = true);
    } else return (this.hasPhoneNumberEntryError = false);
  }

  checkStreetNumberRule(): boolean {
    if (
      !this.regex_streetNumber.test(`${this.dtoObj.AddressItem.StreetNumber}`)
    ) {
      //If the condition fails
      return (this.hasStreetNumberEntryError = true);
    } else return (this.hasStreetNumberEntryError = false);
  }

  checkContactFirstNameRule(): boolean {
    if (!this.regex_contactName.test(`${this.dtoObj.ContactItem.FirstName}`)) {
      //If the condition fails
      return (this.hasContactFirstNameEntryError = true);
    } else return (this.hasContactFirstNameEntryError = false);
  }

  checkContactMiddleNameRule(): boolean {
    if (!this.regex_contactName.test(`${this.dtoObj.ContactItem.MiddleName}`)) {
      //If the condition fails
      return (this.hasContactMiddleNameEntryError = true);
    } else return (this.hasContactMiddleNameEntryError = false);
  }

  checkContactLastNameRule(): boolean {
    if (!this.regex_contactName.test(`${this.dtoObj.ContactItem.LastName}`)) {
      //If the condition fails
      return (this.hasContactLastNameEntryError = true);
    } else return (this.hasContactLastNameEntryError = false);
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

  submitFormToServer() {
    if (this.isSubmissionEnabled()) {
      //Make sure to disable the submission button when the the controls are still missing some details
      //If the string looks good to parse, then send it over to the server
      //generate a post function, to send the data off to the server
      //alert(JSON.stringify(this.dtoObj));
      this.gateway
        .SendInfoToRemoteServer(JSON.stringify(this.dtoObj))
        .subscribe((e: boolean) => {
          if (e) {
            alert('Successfuly submitted form (contact & address details)');
            this.resetFormData(); //Reset the form data after a successful send to the server
          } else alert('Failed to send account information to the server');
        });
    } else {
      alert(
        'Cannot submit these form details to the server. Please fill out all the fields and/or correct the errors before resubmitting'
      );
    }
  }
}

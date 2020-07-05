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
    result = !this.checkBirthDateFormatter(); //Validate Birth Date

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
  regex_phoneNumber: RegExp = new RegExp('^[0-9]{10}$');
  regex_contactName: RegExp = new RegExp('^[a-zA-Z]{3,}$');
  regex_BirthDateUniversal: RegExp = new RegExp(
    '^[0-9]{2}[\\/][0-9]{2}[\\/][0-9]{4}'
  );

  //Show the Error Divs
  hasPostcodeEntryError: boolean = false;
  hasPhoneNumberEntryError: boolean = false;
  hasStreetNumberEntryError: boolean = false;
  hasContactFirstNameEntryError: boolean = false;
  hasContactMiddleNameEntryError: boolean = false;
  hasContactLastNameEntryError: boolean = false;
  hasBirthDateEntryError: boolean = false;

  //Error Messages
  readonly defaultBirthDateError =
    'Birthdate must be in the format of dd/mm/yyyy';
  birthDateErrorMessage: string = `${this.defaultBirthDateError}`; //Default Birthday Error message

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
    //Either a letter exists in the beginning of the query or after
    if (this.dtoObj.AddressItem.StreetNumber.match(/[a-zA-Z]/g).length > 1) {
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
    if (
      !this.regex_contactName.test(`${this.dtoObj.ContactItem.MiddleName}`) &&
      !StringHelper.isEmpty(this.dtoObj.ContactItem.MiddleName)
    ) {
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

  checkBirthDateFormatter(): boolean {
    if (StringHelper.isEmpty(this.dtoObj.ContactItem.DateOfBirth)) {
      //Empty Field
      this.birthDateErrorMessage = 'This field is required';
      return (this.hasBirthDateEntryError = true);
    }

    if (
      //If the Birthday does not meet the format required
      !this.regex_BirthDateUniversal.test(
        `${this.dtoObj.ContactItem.DateOfBirth}`
      )
    ) {
      this.birthDateErrorMessage = this.defaultBirthDateError;
      return (this.hasBirthDateEntryError = true);
    } else {
      //this.hasBirthDateEntryError = false;
      //Check for the first date
      if (
        !StringHelper.isBirthYearValid(
          Number.parseInt(
            this.dtoObj.ContactItem.DateOfBirth.substring(
              6,
              this.birthDateErrorMessage.length
            )
          )
        )
      ) {
        this.birthDateErrorMessage =
          'The specified year is not valid. The year cannot be less than 1923 and not dated sometime in the future';
        return (this.hasBirthDateEntryError = true);
      } else {
        return (this.hasBirthDateEntryError = false);
      }
    }
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

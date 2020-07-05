import { Component } from '@angular/core';
import { UnionDetails } from '../models/unionDetails';

//Models
@Component({
  selector: 'mortgage-house-form',
  templateUrl: './mortgage-house-form.component.html',
  styleUrls: ['./mortgage-house-form.component.css'],
})
export class MortgageFormComponent {
  submitted = false;

  //Data Binding
  dtoObj: UnionDetails;
  streetOptions = ['Street', 'Avenue', 'Court'];
}

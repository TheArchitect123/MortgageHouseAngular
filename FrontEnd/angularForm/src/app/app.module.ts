import { AppComponent } from './app.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { MortgageFormComponent } from './mortgage-house-form/mortgage-house-form.component';
import { NgModule } from '@angular/core';

@NgModule({
  imports: [BrowserModule, FormsModule],
  declarations: [AppComponent, MortgageFormComponent],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

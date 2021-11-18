import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import {DatePipe} from '@angular/common';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { UserDetailsComponent } from './users/user-details/user-details.component';
import { CreateUserComponent } from './users/create-user/create-user.component';
import { CreateIncomeComponent } from './users/create-income/create-income.component';
import { CreateExpenditureComponent } from './users/create-expenditure/create-expenditure.component';
import { UpdateExpenditureComponent } from './users/update-expenditure/update-expenditure.component';
import { UpdateIncomeComponent } from './users/update-income/update-income.component';
import { UpdateUserComponent } from './users/update-user/update-user.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    UserDetailsComponent,
    CreateUserComponent,
    CreateIncomeComponent,
    CreateExpenditureComponent,
    UpdateExpenditureComponent,
    UpdateIncomeComponent,
    UpdateUserComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }

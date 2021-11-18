import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CreateExpenditureComponent } from './users/create-expenditure/create-expenditure.component';
import { CreateIncomeComponent } from './users/create-income/create-income.component';
import { CreateUserComponent } from './users/create-user/create-user.component';
import { UpdateExpenditureComponent } from './users/update-expenditure/update-expenditure.component';
import { UpdateIncomeComponent } from './users/update-income/update-income.component';
import { UpdateUserComponent } from './users/update-user/update-user.component';
import { UserDetailsComponent } from './users/user-details/user-details.component';

const routes: Routes = [
  {path: "", component: HomeComponent},
  {path: "user/details", component: UserDetailsComponent},
  {path: "user/createNewUser", component: CreateUserComponent},
  {path: "user/update", component: UpdateUserComponent},
  {path: "user/createIncome", component: CreateIncomeComponent},
  {path: "user/updateIncome", component: UpdateIncomeComponent},
  {path: "user/createExpenditure", component: CreateExpenditureComponent},
  {path: "user/updateExpenditure", component: UpdateExpenditureComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

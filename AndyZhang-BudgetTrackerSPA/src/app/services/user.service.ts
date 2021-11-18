import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from 'src/app/shared/models/User';
import { environment } from 'src/environments/environment';
import { NewExpenditure } from '../shared/models/Expenditure';
import { NewIncome } from '../shared/models/Income';
import { NewUser } from '../shared/models/NewUser';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getAllUsers(): Observable<User[]> {
    return this.http.get(`${environment.apiUrl}user`).pipe(map(resp => resp as User[]));
  }

  getUser(id: number): Observable<User> {
    let params = new HttpParams().set('id', id);
    return this.http.get(`${environment.apiUrl}user/details`, { params: params }).pipe(map(resp => resp as User));
  }

  createUser(newUser: NewUser): Observable<boolean> {
    return this.http.post(`${environment.apiUrl}user/create`, newUser).pipe(map((response: any) => {
      console.log(response);
      if (response) {
        return true;
      }
      return false;
    }));    
  }

  updateUser(updateUser: NewUser, id: number): Observable<boolean> {
    let params = new HttpParams().set('id', id);

    return this.http.put(`${environment.apiUrl}user/update`, updateUser, { params: params }).pipe(map((response: any) => {
      if (response) {
        return true;
      }
      return false;
    }));    
  }

  deleteUser(id: number): Observable<boolean> {
    let params = new HttpParams().set('id', id);

    return this.http.delete(`${environment.apiUrl}user/delete`, { params: params }).pipe(map((response: any) => {
      if (response) {
        return true;
      }
      return false;
    }));    
  }

  createIncome(newIncome: NewIncome): Observable<boolean> {
    return this.http.post(`${environment.apiUrl}income/create`, newIncome).pipe(map((response: any) => {
      if (response) {
        return true;
      }
      return false;
    }));    
  }

  updateIncome(updateIncome: NewIncome, id: number): Observable<boolean> {
    let params = new HttpParams().set('id', id);

    return this.http.put(`${environment.apiUrl}income/update`, updateIncome, { params: params }).pipe(map((response: any) => {
      if (response) {
        return true;
      }
      return false;
    }));    
  }

  deleteIncome(id: number): Observable<boolean> {
    let params = new HttpParams().set('id', id);

    return this.http.delete(`${environment.apiUrl}income/delete`, { params: params }).pipe(map((response: any) => {
      if (response) {
        return true;
      }
      return false;
    }));    
  }

  createExpenditure(newExpenditure: NewExpenditure): Observable<boolean> {
    return this.http.post(`${environment.apiUrl}expenditure/create`, newExpenditure).pipe(map((response: any) => {
      if (response) {
        return true;
      }
      return false;
    }));    
  }

  updateExpenditure(updateExpenditure: NewExpenditure, id: number): Observable<boolean> {
    let params = new HttpParams().set('id', id);

    return this.http.put(`${environment.apiUrl}expenditure/update`, updateExpenditure, { params: params }).pipe(map((response: any) => {
      if (response) {
        return true;
      }
      return false;
    }));    
  }

  deleteExpenditure(id: number): Observable<boolean> {
    let params = new HttpParams().set('id', id);

    return this.http.delete(`${environment.apiUrl}expenditure/delete`, { params: params }).pipe(map((response: any) => {
      if (response) {
        return true;
      }
      return false;
    }));    
  }
}

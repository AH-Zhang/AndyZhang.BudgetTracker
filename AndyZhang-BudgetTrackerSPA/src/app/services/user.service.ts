import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from 'src/app/shared/models/User';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getAllUsers(): Observable<User[]> {
    return this.http.get(`${environment.apiUrl}user`).pipe(map(resp => resp as User[]));
  }

  getUser(id: number): Observable<User> {
    return this.http.get(`${environment.apiUrl}user/details/${id}`).pipe(map(resp => resp as User));;
  }
}

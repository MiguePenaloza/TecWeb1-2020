import { UserManagerResponse } from './../models/authentication/UserManagerResponse';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Login } from '../models/authentication/Login';
import { CreateAccount } from '../models/authentication/CreateAccount';

var httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  authUrl :string = 'https://localhost:44317/api/auth';

  constructor(private http :HttpClient) { }

  login(login :Login) :Observable<UserManagerResponse> {
    return this.http.post<UserManagerResponse>(`${this.authUrl}/login`, login, httpOptions);
  }

  registerUser(createAccount :CreateAccount) :Observable<UserManagerResponse> {
    return this.http.post<UserManagerResponse>(`${this.authUrl}/user`, createAccount, httpOptions);
  }
}

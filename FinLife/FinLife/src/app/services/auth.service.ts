import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { user } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  [x: string]: any;
  public _user: user = new user;

  constructor(private http: HttpClient) { }

    baseServerUrl = "http://localhost:5023/api/";

    loginUser(user: user)
  {
    return this.http.post(this.baseServerUrl + 'Login/Login', {
      emailId: user.emailId,
      password: user.password,
      role: user.role
    },
    {
      responseType: 'json',
    }
    );
  }






}

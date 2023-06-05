
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { user } from 'src/app/models/user';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{

  constructor(private loginAuth : AuthService, private router: Router) {}

  ngOnInit(): void {}

  loginForm = new FormGroup({
    email: new FormControl("", [Validators.required, Validators.email]),
    pwd: new FormControl("", [Validators.required, Validators.minLength(6), Validators.maxLength(15)])
  });

  isUserValid: boolean = false;
  public _user: user = new user;
  data : any;

  loginSubmitted(){

    this._user.emailId = this.loginForm.value.email ?? "";
    this._user.password = this.loginForm.value.pwd ?? "";

      this.loginAuth.loginUser(
        this._user
      )
      .subscribe(res => {
        if (res == 'Failure') {
          this.isUserValid = false;
          alert('Login Unsuccessful');
        } else {
          this.isUserValid = true;
          alert('Login Successful');
          this.data = res;
          this._user = this.data;
          if(this._user.role == 'A'){
            this.router.navigateByUrl('/admin')
          }
          else if(this._user.role == 'V'){
            alert('vendor');
          }
          else if(this._user.role == 'R'){
            alert('risk');
          }
        }
      });
  }

  get Email(): FormControl{
    return this.loginForm.get('email') as FormControl;
  }
  get PWD(): FormControl{
    return this.loginForm.get('pwd') as FormControl;
  }
}




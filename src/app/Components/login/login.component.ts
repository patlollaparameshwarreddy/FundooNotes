import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AppService } from 'src/app/services/UserServices/app.service';
import * as jwt_decode from "jwt-decode";
import { AuthService, FacebookLoginProvider, GoogleLoginProvider, LinkedinLoginProvider } from 'angular-6-social-login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  token: string;
  payLoad: any;

  constructor(private service: AppService, private router: Router, private socialAuthService: AuthService) { }
  email = new FormControl('', [Validators.required, Validators.email]);
  password = new FormControl('', [Validators.required]);

  ngOnInit() {
  }
  login() {
    var user = {
      "email": this.email.value,
      "password": this.password.value
    }
    this.service.loginPostRequest('login', user).subscribe((data: any) => {
      // localStorage.setItem('Email', this.email.value);
      console.log(data.user)
      console.log(data.token);
      localStorage.setItem('token', data.token);
      localStorage.setItem('email', data.user.email);
      localStorage.setItem('firstname', data.user.firstName);
      localStorage.setItem('lastname', data.user.lastName);
      localStorage.setItem('imgUrl',data.user.profilePic);

      // localStorage.setItem('firstname',)
      this.token = localStorage.getItem('token')
      this.payLoad = jwt_decode(this.token)
      console.log(this.payLoad.UserID);

      localStorage.setItem('UserId', this.payLoad.UserID);
      this.router.navigate(['dashboard']);

    }, err => {
      alert("login failed");
      console.log(err);

    })
  }
  public socialSignIn(socialPlatform: string) {
    let socialPlatformProvider;
    if (socialPlatform == "facebook") {
      socialPlatformProvider = FacebookLoginProvider.PROVIDER_ID;
    }
    this.socialAuthService.signIn(socialPlatformProvider).then(
      (userData) => {
        console.log(socialPlatform+" sign in data : " , userData);
        console.log(userData.email,"email from fb")
        this.service.fbLogin(userData.email).subscribe((data: any) => {
          // localStorage.setItem('Email', this.email.value);
          console.log(data.user)
          console.log(data.token);
          localStorage.setItem('token', data.token);
          localStorage.setItem('email', data.user.email);
          localStorage.setItem('firstname', data.user.firstName);
          localStorage.setItem('lastname', data.user.lastName);
          localStorage.setItem('imgUrl',data.profilePic);
          // localStorage.setItem('firstname',)
          this.token = localStorage.getItem('token')
          this.payLoad = jwt_decode(this.token)
          console.log(this.payLoad.UserID);
    
          localStorage.setItem('UserId', this.payLoad.UserID);
          this.router.navigate(['dashboard']);
    
        }, err => {
          alert("login failed");
          console.log(err);
    
        })
      }
    );
  }
}

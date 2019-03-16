import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import {AppService  } from "../app.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private service:AppService) { }
  email=new FormControl('',[Validators.required,Validators.email]);
password=new FormControl('',[Validators.required]);

  ngOnInit() {
  }
  login(){
    var user ={
    "email": this.email.value,
    "password":this.password.value
    }
    this.service.loginPostRequest('login',user).subscribe(data=>{
      console.log(data);
      
    },err=>{
      console.log(err);
      
    })
  }
}

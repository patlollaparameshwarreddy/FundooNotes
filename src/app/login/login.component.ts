import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import {AppService  } from "../app.service";
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private service:AppService,private router:Router) { }
  email=new FormControl('',[Validators.required,Validators.email]);
password=new FormControl('',[Validators.required]);

  ngOnInit() {
  }
  login(){
    var user ={
    "email": this.email.value,
    "password":this.password.value
    }
    this.service.loginPostRequest('login',user).subscribe((data:any) =>{
      localStorage.setItem('Email', this.email.value);
      console.log(data);
     
        this.router.navigate(['dashboard']);
        
    },err=>{
      alert("login failed");
      console.log(err);
      
    })
  }
}

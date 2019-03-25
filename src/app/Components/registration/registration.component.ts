import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, RequiredValidator } from '@angular/forms';
import { AppService } from 'src/app/services/UserServices/app.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  constructor(private service:AppService) { }
firstName=new FormControl('',[Validators.required,Validators.pattern('[a-zA-Z]*')]);
lastName=new FormControl('',[Validators.required,Validators.pattern('[a-zA-Z]*')]);
email=new FormControl('',[Validators.email,Validators.required]);
password=new FormControl('',Validators.required);
ConfirmPassword = new FormControl('',Validators.required);
firstNameErrorMessage(){
  return this.firstName.hasError('required') ? 'Enter the name':
  this.firstName.hasError('pattern') ? 'Enter a valid name':
  '';
}
  ngOnInit() {
  }
  signUp(){
    var user ={
    "firstName":this.firstName.value,
    "lastName":this.lastName.value,
    "emailId": this.email.value,
    "password":this.password.value
    }
    //console.log(user);
    if(this.password.value == this.ConfirmPassword.value)
    {
      this.service.postRequest('registration',user).subscribe(data=>{
        console.log(data);
      },err=>{
        console.log(err);
        
      })
    }

    
  }
  }
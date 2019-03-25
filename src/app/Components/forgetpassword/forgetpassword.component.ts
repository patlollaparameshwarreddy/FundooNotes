import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { ForgetpasswordService } from 'src/app/services/UserServices/forgetpassword.service';


@Component({
  selector: 'app-forgetpassword',
  templateUrl: './forgetpassword.component.html',
  styleUrls: ['./forgetpassword.component.scss']
})
export class ForgetpasswordComponent implements OnInit {

  constructor(private service:ForgetpasswordService) { }

  ngOnInit() {
  }
email = new FormControl('',[Validators.required,Validators.email]);
forgetpassword(){
  var user ={
    "email":this.email.value
  }

this.service.ForgetpasswordService('forgetpassword',user).subscribe(data=>{
  console.log(data);
  
},err=>{
  console.log(err);

})
}
}

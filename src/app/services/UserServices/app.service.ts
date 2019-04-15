import { Injectable } from '@angular/core';
import {  HttpClient} from '@angular/common/http';
import { stringify } from '@angular/core/src/render3/util';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor(private http:HttpClient) { }
  link = 'https://localhost:44360/api/user/'
  postRequest(url, user){ 
   return this.http.post(this.link + url,user);
  }

  loginPostRequest(url,user){
    return this.http.post(this.link + url,user);
  }

  profilepic(path,useid){
    return this.http.post(this.link + 'profile/' + useid,
    {
      params:
      {
        path:path
      }
    })
  }

  fbLogin(email)
  {
    const obj={email:email}
    console.log(typeof {email:email},"serviceeee")
    return this.http.post(this.link +'fblogin?email='+email,'')
  }
}

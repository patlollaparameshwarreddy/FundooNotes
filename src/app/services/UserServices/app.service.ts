import { Injectable } from '@angular/core';
import {  HttpClient} from '@angular/common/http';

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
}

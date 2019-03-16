import { Injectable } from '@angular/core';
import {  HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ForgetpasswordService {

  constructor(private http:HttpClient) { }
  link = 'https://localhost:44360/api/user/'
  ForgetpasswordService(url, user)
  {
    console.log('test'+this.link + url);
    
    return this.http.post(this.link + url,user);
  }
}

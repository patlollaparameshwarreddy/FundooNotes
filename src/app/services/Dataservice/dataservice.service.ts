import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataserviceService {

  private messageSource = new BehaviorSubject('default message');
  currentMessage = this.messageSource.asObservable();

  constructor() { }
  changeMessage(message: string) {
    console.log(message,"dataservice");
    
    this.messageSource.next(message)
  }

}

import { Injectable } from '@angular/core';
import {  HttpClient} from '@angular/common/http';
import {map} from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class NotesService {
  Email: any = localStorage.getItem('Email');
  constructor(private http:HttpClient) { }
  link = 'https://localhost:44360/api/notes';
  
  AddNotes(data)
  {
    console.log(data);
    return this.http.post(this.link, data);
  }

  getNotes(userId){
    console.log(userId);
  return this.http.get(this.link,
   { params:{
    userId:userId
  } });
}

deleteNote(id){
  return this.http.delete(this.link + id);
}

}

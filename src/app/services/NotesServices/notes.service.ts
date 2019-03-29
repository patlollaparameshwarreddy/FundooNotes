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

deleteNote(result){
  return this.http.delete(this.link,
    { params:{
      id:result.id
    }
    });
}

loggedIn()
{
  return !!localStorage.getItem('token')
}

 updateNotes(result)
 {
   console.log(this.link,'notes' + result.id )
   return this.http.put('https://localhost:44360/api/notes/notes/' + result.id, result );
 }

 archiveNotes(userId){
  return this.http.get(this.link + '/' + 'archive',
   { params:{
    userId:userId
  } });
 }
}

import { Injectable } from '@angular/core';
import {  HttpClient} from '@angular/common/http';
import {map} from 'rxjs/operators';
import { Subject } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class NotesService {
  Email: any = localStorage.getItem('Email');
  constructor(private http:HttpClient) { }
  result:boolean = true;
  subject = new Subject();
  link = 'https://localhost:44360/api/notes';
  
  AddNotes(data)
  {
    return this.http.post(this.link, data);
  }

  getNotes(userId){
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

  getView() {
    this.gridview();
    return this.subject.asObservable();
  }
  gridview(){
    if(this.result){
      this.subject.next({data:"column"});
      this.result = false;
    }
    else{
      this.subject.next({data:"row"});
      this.result = true;
    }
  }

  getlabels(userId){
  return this.http.get(this.link + '/' + 'labels',
  {
    params:{
      userId:userId
    }
  });
  }

  AddLabels(result)
  {
    return this.http.post(this.link + '/' + 'labels', result)
  }

  AddNotesLabels(notesLabel)
  {
    return this.http.post(this.link + '/' + 'NotesLabel', notesLabel)
  }

  getNotesLabels(userid)
  {
    return this.http.get(this.link +'/'+'noteslabel',
    {
      params:{
        userId:userid
      }
    })
  }
}

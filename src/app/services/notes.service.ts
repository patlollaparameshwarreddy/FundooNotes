import { Injectable } from '@angular/core';
import {  HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class NotesService {

  constructor(private http:HttpClient) { }
  link = 'https://localhost:44360/api/notes/addnotes';
  AddNotes(data)
  {
    return this.http.post(this.link, data);
  }
}

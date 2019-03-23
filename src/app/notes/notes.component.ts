import { Component, OnInit } from '@angular/core';
import { NotesService } from '../services/notes.service';
import * as jwt_decode from "jwt-decode";

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss']
})
export class NotesComponent implements OnInit {
  token:any;
  payLoad : any;
  card=[];
  title=[];
  constructor(private service:NotesService) { }

  ngOnInit() {
    this.token = localStorage.getItem('token')
   this.payLoad = jwt_decode(this.token)
   console.log(this.payLoad);
    this.getallcards()
  }
  getallcards(){
    this.service.getNotes(this.payLoad.UserID).subscribe((data: any) => {
      this.title = data;
      console.log(this.card);
     })
    
  }

}

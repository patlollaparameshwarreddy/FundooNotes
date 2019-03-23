import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import {NotesService} from '.././services/notes.service';
import * as jwt_decode from "jwt-decode";

@Component({
  selector: 'app-takenote',
  templateUrl: './takenote.component.html',
  styleUrls: ['./takenote.component.scss']
})
export class TakenoteComponent implements OnInit {

  constructor(private service : NotesService) { }
  title = new FormControl('', [Validators.required, Validators.required]);
  TakeANote = new FormControl('', [Validators.required, Validators.required]);
  notes: any;
  token:any;
  payLoad : any
  ngOnInit() {
  this.token = localStorage.getItem('token')
   this.payLoad = this.getDecodedAccessToken(this.token)
   console.log(this.payLoad);
   console.log(this.payLoad.UserID)
  }

  getDecodedAccessToken(token:string):any
  {
    try {
      return jwt_decode(token)
    } catch (error) {
      return null;
    }
  };
  
  AddNotes()
  {
    var data = {
      "title":this.title.value,
      "TakeANote":this.TakeANote.value,
      "userId":this.payLoad.UserID
    }
    console.log(data);
    this.service.AddNotes(data).subscribe(data=>{
      // this.service.getNotes(this.payLoad.UserID).subscribe((data: any) => {
      //   console.log('data: ', data.noteData);
      //   this.notes = data.notesData;
      //   console.log(this.notes);
      // });
    },err=>{
      console.log(err);
      
    })

  }

}

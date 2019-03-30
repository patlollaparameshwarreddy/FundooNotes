import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import * as jwt_decode from "jwt-decode";
import { NotesService } from 'src/app/services/NotesServices/notes.service';

@Component({
  selector: 'app-takenote',
  templateUrl: './takenote.component.html',
  styleUrls: ['./takenote.component.scss']
})
export class TakenoteComponent implements OnInit {

  constructor(private service : NotesService) { }
  title = new FormControl('', [Validators.required, Validators.required]);
  TakeANote = new FormControl('', [Validators.required, Validators.required]);
  token:any;
  payLoad : any;
  cards : any;
  bgcolor:any;

  DialogData=[];
  ngOnInit() {
  this.token = localStorage.getItem('token')
   this.payLoad = this.getDecodedAccessToken(this.token)
  }

  getDecodedAccessToken(token:string):any
  {
    try {
      return jwt_decode(token)
    } catch (error) {
      return null;
    }
  };
  setcolor($event){
    console.log($event,"color")
    this.bgcolor=$event
  }
  AddNotes()
  {
    var data = {
      "title":this.title.value,
      "TakeANote":this.TakeANote.value,
      "userId":this.payLoad.UserID,
      "colorCode":this.bgcolor
    }
    console.log(data);
    if(data.title != "" || data.TakeANote != "")
    {
    this.service.AddNotes(data).subscribe(data=>{

    },err=>{
      console.log(err);
      
    })
  }

  }
}


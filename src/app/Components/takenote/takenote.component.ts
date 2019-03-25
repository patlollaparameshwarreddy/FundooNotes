import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import * as jwt_decode from "jwt-decode";
import { NotesService } from 'src/app/services/NotesServices/notes.service';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import { NoteDialogComponent } from '../note-dialog/note-dialog.component';

@Component({
  selector: 'app-takenote',
  templateUrl: './takenote.component.html',
  styleUrls: ['./takenote.component.scss']
})
export class TakenoteComponent implements OnInit {

  constructor(private service : NotesService,public dialog: MatDialog) { }
  title = new FormControl('', [Validators.required, Validators.required]);
  TakeANote = new FormControl('', [Validators.required, Validators.required]);
  token:any;
  payLoad : any;
  cards : any;

  DialogData=[];
  ngOnInit() {
  this.token = localStorage.getItem('token')
   this.payLoad = this.getDecodedAccessToken(this.token)
  //  console.log(this.payLoad);
  //  console.log(this.payLoad.UserID)
  this.getallnotes();
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
    if(data.title != "" || data.TakeANote != "")
    {
    this.service.AddNotes(data).subscribe(data=>{

    },err=>{
      console.log(err);
      
    })
  }

  }

  getallnotes()
  {
    this.service.getNotes(this.payLoad.UserID).subscribe(data =>{
      this.cards=data["notesData"];
      console.log(this.cards);

    },err=>{
      console.log(err);
      

    })
  }
  noteDialog(note){
    
      const dialogRef = this.dialog.open(NoteDialogComponent, {
        width: '250px',
      });
  
      dialogRef.afterClosed().subscribe(result => {
        console.log('The dialog was closed');
      });
    
  
  }
  }


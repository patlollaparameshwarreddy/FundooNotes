import { Component, OnInit, Input } from '@angular/core';
import * as jwt_decode from "jwt-decode";
import { NotesService } from 'src/app/services/NotesServices/notes.service';
import { MatDialogConfig, MatDialog } from '@angular/material';
import { NoteDialogComponent } from '../note-dialog/note-dialog.component';


@Component({
  selector: 'app-displaynotes',
  templateUrl: './displaynotes.component.html',
  styleUrls: ['./displaynotes.component.scss']
  
})
export class DisplaynotesComponent implements OnInit 
{
  token:any;
  payLoad : any;
  cards : any;


  constructor(private notes:NotesService, private dialog: MatDialog) { }

  ngOnInit() {
  this.token = localStorage.getItem('token')
   this.payLoad =  jwt_decode(this.token)
  this.getallnotes();
  }
  getallnotes()
  {
    this.notes.getNotes(this.payLoad.UserID).subscribe(data =>{
      this.cards=data["notesData"];
      console.log(this.cards);

    },err=>{
      console.log(err);
      
    })
  }

  openDialog(note) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = "some data";
    let dialogRef = this.dialog.open(NoteDialogComponent,{
      maxWidth:'auto',
      height:'auto',
      data:{note}
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
      this.notes.updateNotes(result).subscribe(data =>{
        console.log(data);
      },err=>{
        console.log(err);
      })
      })
    }
  }
  
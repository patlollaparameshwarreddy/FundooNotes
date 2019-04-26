import { Component, OnInit } from '@angular/core';
import { NotesService } from '../../services/NotesServices/notes.service';
import { MatDialogConfig, MatDialog } from '@angular/material';
import { NoteDialogComponent } from '../note-dialog/note-dialog.component';

@Component({
  selector: 'app-collaborated-notes',
  templateUrl: './collaborated-notes.component.html',
  styleUrls: ['./collaborated-notes.component.scss']
})
export class CollaboratedNotesComponent implements OnInit {
  userEmail:any
  noteCards:any
  notesCollaborator: Object;
  userId=localStorage.getItem("UserId");
  constructor(private notes: NotesService,private dialog: MatDialog ) { 
    this.notes. getAllCollaboratedData(this.userId).subscribe(result =>{
      this.notesCollaborator = result;
    }, err => {
      console.log(err);
      
    })
  }

  ngOnInit() {

    this.userEmail = localStorage.getItem("email");
    this.getallnotes();
  }
  
  getallnotes()
  {
    this.notes.collaboratednotes(this.userEmail).subscribe(data =>{
      this.noteCards = data;
    },err=>{
      console.log(err);
      
    })
  }

  openDialog(note) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = "some data";
    let dialogRef = this.dialog.open(NoteDialogComponent, {
      maxWidth: 'auto',
      height: 'auto',
      data: { note }
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
      this.notes.updatecollaborated(result.noteId,result).subscribe(data => {
        console.log(data);
      }, err => {
        console.log(err);
      })
    })
  }
}

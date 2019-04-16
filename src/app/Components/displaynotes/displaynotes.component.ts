import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import * as jwt_decode from "jwt-decode";
import { NotesService } from 'src/app/services/NotesServices/notes.service';
import { MatDialogConfig, MatDialog } from '@angular/material';
import { NoteDialogComponent } from '../note-dialog/note-dialog.component';
import { conditionallyCreateMapObjectLiteral } from '@angular/compiler/src/render3/view/util';


@Component({
  selector: 'app-displaynotes',
  templateUrl: './displaynotes.component.html',
  styleUrls: ['./displaynotes.component.scss']

})
export class DisplaynotesComponent implements OnInit {
  token: any;
  payLoad: any;
  cards: any;
  allLabels: any;
  notesLabels: any;
  userId;
  searchText;
  @Input() noteCards = [];
  @Input() type;
  @Output() cardUpdate = new EventEmitter();

  @Input() cond;
  constructor(private notes: NotesService, private dialog: MatDialog) {
    this.userId = localStorage.getItem("UserId")

    this.notes.getlabels(this.userId).subscribe(responselabels => {
      this.allLabels = responselabels;
      console.log(this.allLabels, "all labels")
    }, err => {
      console.log(err);
    })

    this.notes.getNotesLabels(this.userId).subscribe(response => {
      this.notesLabels = response;
      console.log(this.notesLabels, "notes labels")
    }, err => {
      console.log(err);
    })
  }

  ngOnInit() {
    this.token = localStorage.getItem('token')
    this.payLoad = jwt_decode(this.token)
    // this.getallnotes();
    console.log(this.cards);
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
      this.notes.updateNotes(result).subscribe(data => {
        console.log(data);
      }, err => {
        console.log(err);
      })
    })
  }

  DeleteForever(note) {

    this.notes.deleteNote(note).subscribe(data => {
      console.log(note);
      this.cardUpdate.emit({})
    }, err => {
      console.log(err);
    })
  }

  Restore(card) {
    card.delete = false;
    card.IsTrash = card.delete;
    this.notes.updateNotes(card).subscribe(data => {
      console.log(data);
      this.cardUpdate.emit({})
    }, err => {
      console.log(err);
    })
  }
  updateCome(value) {
    this.cardUpdate.emit({});
  }
  remove(id) {
    console.log(id, "lable");
    this.notes.deleteNotelabel(id).subscribe(result =>
       { 
      console.log(result);
    }, err => {
      console.log(err);
    })
  }

  removeReminder(note)
  {
    note.reminder=null;
    this.notes.updateNotes(note).subscribe(data =>{
      console.log(data);
    },err =>{
      console.log(err);
    })
  }
}
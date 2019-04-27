import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import * as jwt_decode from "jwt-decode";
import { NotesService } from 'src/app/services/NotesServices/notes.service';
import { MatDialogConfig, MatDialog } from '@angular/material';
import { NoteDialogComponent } from '../note-dialog/note-dialog.component';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import {DataserviceService} from '../../services/Dataservice/dataservice.service'
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
  notesCollaborator: any;
  searchText:string=''
  @Input() search;
  @Input() noteCards = [];
  @Input() type;
  @Output() cardUpdate = new EventEmitter();

  @Input() cond;
  constructor(private notes: NotesService, private dialog: MatDialog,private data:DataserviceService) {
    this.userId = localStorage.getItem("UserId")
    this.notes.getlabels(this.userId).subscribe(responselabels => {
      this.allLabels = responselabels;
    }, err => {
      console.log(err);
    })

    this.notes.getNotesLabels(this.userId).subscribe(response => {
      this.notesLabels = response;
    }, err => {
      console.log(err);
    })

    this.notes. getAllCollaboratedData(this.userId).subscribe(result =>{
      // console.log(result,"check");
      this.notesCollaborator = result;
    }, err => {
      console.log(err);
      
    })
  }

  ngOnInit() {
    this.token = localStorage.getItem('token')
    this.payLoad = jwt_decode(this.token)
    // this.getallnotes();
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

  pinnote(note)
  {
    note.isPin = true;
    note.isPin = note.isPin;
    this.notes.updateNotes(note).subscribe(data =>{
    },err =>{
      console.log(err);
    })
  }

  unpinnote(note)
  {
    note.isPin = false;
    note.isPin = note.isPin;
    this.notes.updateNotes(note).subscribe(data =>{
      console.log(data);
    },err =>{
      console.log(err);
    })
  }

  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.noteCards, event.previousIndex, event.currentIndex);
    console.log(event.previousIndex,"previousss");
    console.log(event.currentIndex,"currenttt");
    console.log(event.container);

  }

  removeCollaborator(id)
  {
    this.notes.removeCollaborator(id).subscribe(data =>{
      console.log(data);
    },err =>{
      console.log(err);
      
    })
  }
}
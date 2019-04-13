import { Component, OnInit, Input, Output } from '@angular/core';
import { MatCard, MatDialogConfig, MatDialog } from '@angular/material';
import { NotesService } from 'src/app/services/NotesServices/notes.service';
import { EventEmitter } from '@angular/core';
import { CollaboratordialogComponent } from 'src/app/collaboratordialog/collaboratordialog.component';


@Component({
  selector: 'app-iconlist',
  templateUrl: './iconlist.component.html',
  styleUrls: ['./iconlist.component.scss']
})
export class IconlistComponent implements OnInit {
  getColor
  notesLabel: any;
  userId:any;
  constructor(private notes:NotesService,private dialog: MatDialog) { 
    this.userId = localStorage.getItem('UserId')
    this.notes.getlabels(this.userId).subscribe(responselabels => {
      this.notesLabel = responselabels;
      console.log(this.notesLabel)
    },err=>{
      console.log(err);
    })
  }
  @Input() card;
  @Input() type;
  @Output() update =new EventEmitter();
  @Output() setcolortoNote = new EventEmitter()
  ngOnInit() {
    console.log(this.type,"in consoli")
  }
  setcolor(color: any,card) {
    if(card==undefined){
        this.setcolortoNote.emit(color)
    }
    else{
    console.log(card,"card")
    card.color = color;
    card.colorCode = card.color;
    this.notes.updateNotes(card).subscribe(data =>{
      console.log(data);
    },err=>{
      console.log(err);
    })
  }
  }

  setArchive(card)
  {
    card.setArchive = true;
    card.isArchive = card.setArchive;
    console.log(card);
    this.notes.updateNotes(card).subscribe(data =>{
      console.log(data);
      this.update.emit({});
    },err=>{
      console.log(err);
    })
  }

  doUnArchive(card)
  {
    card.setArchive = false;
    card.isArchive = card.setArchive;
    console.log(card);
    this.notes.updateNotes(card).subscribe(data =>{
      console.log(data);
      this.update.emit({});
    },err=>{
      console.log(err);
    })
  }

  DeleteNote(card)
  {
    card.delete = true;
    card.IsTrash = card.delete;
    this.notes.updateNotes(card).subscribe(data =>{
      console.log(data);
      this.update.emit({});
    },err =>{
      console.log(err);
    })
  }

  LabelList(label)
  {
    console.log(label.id);
    console.log(this.card.id);
    this.userId = localStorage.getItem('UserId')
    var notesLabel = {
      "LableId":label.id,
      "NoteId":this.card.id,
      "UserId":this.userId
    }
    console.log(notesLabel);
    this.notes.AddNotesLabels(notesLabel).subscribe(data => {
      console.log(data);
    },err =>{
      console.log(err);
    }
    )
  }

  Today(card)
  {
    var date = new Date();
    date.setHours(20,0,0)
    card.reminder = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate() + " " +  date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
    this.notes.updateNotes(card).subscribe(data =>{
      console.log(data);
      this.update.emit({});
    },err =>{
      console.log(err);
    })
  }

  Tomorrow(card)
  {
    var date = new Date();
    date.setHours(8,0,0)
    card.reminder = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + (date.getDate()+1) + " " +  date.getHours() + ":" + date.getMinutes();
    this.notes.updateNotes(card).subscribe(data =>{
      console.log(data);
      this.update.emit({});
    },err =>{
      console.log(err);
    })
  }

  nextWeek(card)
  {
    var date = new Date();
    date.setHours(8,0,0)
    card.reminder = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + (date.getDate()+7) + " " +  date.getHours() + ":" + date.getMinutes();
    this.notes.updateNotes(card).subscribe(data =>{
      console.log(data);
      this.update.emit({});
    },err =>{
      console.log(err);
    })
  }

  openDialog(): void {
    const dialogConfig = new MatDialogConfig();
    let dialogRef = this.dialog.open(CollaboratordialogComponent, {

    });
  }
}

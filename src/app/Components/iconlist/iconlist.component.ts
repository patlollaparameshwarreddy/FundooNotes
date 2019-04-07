import { Component, OnInit, Input, Output } from '@angular/core';
import { MatCard } from '@angular/material';
import { NotesService } from 'src/app/services/NotesServices/notes.service';
import { EventEmitter } from '@angular/core';


@Component({
  selector: 'app-iconlist',
  templateUrl: './iconlist.component.html',
  styleUrls: ['./iconlist.component.scss']
})
export class IconlistComponent implements OnInit {
  getColor
  notesLabel: any;
  userId:any;
  constructor(private notes:NotesService) { 
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
}

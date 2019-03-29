import { Component, OnInit, Input } from '@angular/core';
import { MatCard } from '@angular/material';
import { NotesService } from 'src/app/services/NotesServices/notes.service';

@Component({
  selector: 'app-iconlist',
  templateUrl: './iconlist.component.html',
  styleUrls: ['./iconlist.component.scss']
})
export class IconlistComponent implements OnInit {
  getColor
  constructor(private notes:NotesService) { }
  @Input() card;
  ngOnInit() {
    // console.log(this.card,"in consoli")
  }
  setcolor(color: any,card) {
    console.log(card,"card")
    card.color = color;
    card.colorCode = card.color;
    this.notes.updateNotes(card).subscribe(data =>{
      console.log(data);
    },err=>{
      console.log(err);
    })
  }

  setArchive(card)
  {
    card.setArchive = true;
    card.isArchive = card.setArchive;
    console.log(card);
    this.notes.updateNotes(card).subscribe(data =>{
      console.log(data);
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
    },err =>{
      console.log(err);
    })
  }

  DeleteForever(card)
  {
    this.notes.deleteNote(card).subscribe(data => {
      console.log(data);
    },err =>{
      console.log(err);
    })
  }

  Restore(card)
  {
    card.delete = false;
    card.IsTrash = card.delete;
    this.notes.updateNotes(card).subscribe(data =>{
      console.log(data);
    },err =>{
      console.log(err);
    })
  }
}

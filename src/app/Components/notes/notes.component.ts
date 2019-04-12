import { Component, OnInit, Output, EventEmitter  } from '@angular/core';
import * as jwt_decode from "jwt-decode";
import { NotesService } from 'src/app/services/NotesServices/notes.service';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss']
})
export class NotesComponent implements OnInit {
  token:any;
  payLoad : any;
  cards : any;
  noteCards = [];


  // cards: any = [];
  wrap:string="wrap";
  direction
  view
  layout
  constructor(private notes:NotesService) { }

  ngOnInit() {
    this.token = localStorage.getItem('token')
    this.payLoad =  jwt_decode(this.token)
   this.getallnotes();
   console.log(this.cards);

   this.notes.getView().subscribe((res:any)=>{
    // debugger
      this.view = res;
      this.direction = this.view.data;
      this.layout = this.direction + " " + this.wrap;
  });
  }

  getallnotes()
  {
    this.notes.getNotes(this.payLoad.UserID).subscribe(data =>{
      console.log(data,"notes.ts");
      this.noteCards=[];
      this.cards=data["notesData"];
      console.log(this.cards);
      this.cards.forEach(element => {
        if(element.isArchive || element.isTrash){
          return;
        }
        else
        this.noteCards.push(element);

        
      });
      console.log(this.cards);

    },err=>{
      console.log(err);
      
    })
  }
  update(value){
    console.log(value,'event');
    this.getallnotes();
    
  }
  closed(value){
    console.log(value,"from take note");
    this.getallnotes();
  }

}

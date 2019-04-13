import { Component, OnInit } from '@angular/core';
import { NotesService } from 'src/app/services/NotesServices/notes.service';
import * as jwt_decode from "jwt-decode";

@Component({
  selector: 'app-trash',
  templateUrl: './trash.component.html',
  styleUrls: ['./trash.component.scss']
})
export class TrashComponent implements OnInit {
  cards;
  trashCards=[];
  token:any;
  decodedToken : any;
  trash='trash'
  constructor(private notes:NotesService) { }

  ngOnInit() {
    this.token = localStorage.getItem('token')
   this.decodedToken =  jwt_decode(this.token)
   this.getAllTrashcards()
  }

  getAllTrashcards(){
    console.log("archive");
    this.notes.getNotes(this.decodedToken.UserID).subscribe(data =>{
      this.cards=data[0].notesData;
      this.cards.forEach(element => {
        if(element.isTrash){
          this.trashCards.push(element);
        }
        else{
          return;
        }
      });
  })
}

DeletedNotes($event)
{
  this.getAllTrashcards()
}
}

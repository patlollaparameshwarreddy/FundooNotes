import { Component, OnInit } from '@angular/core';
import { NotesService } from 'src/app/services/NotesServices/notes.service';
import * as jwt_decode from "jwt-decode";

@Component({
  selector: 'app-archive',
  templateUrl: './archive.component.html',
  styleUrls: ['./archive.component.scss']
})
export class ArchiveComponent implements OnInit {
cards;
archiveCards=[];
archive='archive'
token:any;
decodedToken : any;
wrap:string="wrap";
  direction
  view
  layout
  constructor(private notes:NotesService) { }

  ngOnInit() {
    this.token = localStorage.getItem('token')
   this.decodedToken =  jwt_decode(this.token)
   this.getAllArchivecards()

   this.notes.getView().subscribe((res:any)=>{
    // debugger
      this.view = res;
      this.direction = this.view.data;
      this.layout = this.direction + " " + this.wrap;
  });
  }
  getAllArchivecards(){
    console.log("archive");
    this.notes.archiveNotes(this.decodedToken.UserID).subscribe(data =>{
      this.archiveCards=data["notesData"];
      console.log(this.archiveCards)
  })
}

Archived($event){
  this.getAllArchivecards();
}
}


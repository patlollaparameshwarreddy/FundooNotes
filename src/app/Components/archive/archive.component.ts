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
token:any;
decodedToken : any;
  constructor(private notes:NotesService) { }

  ngOnInit() {
    this.token = localStorage.getItem('token')
   this.decodedToken =  jwt_decode(this.token)
   this.getAllArchivecards()
  }
  getAllArchivecards(){
    console.log("archive");
    this.notes.archiveNotes(this.decodedToken.UserID).subscribe(data =>{
      this.archiveCards=data["notesData"];
      console.log(this.archiveCards)
  })
}
}


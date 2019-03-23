import { Component, OnInit, Input } from '@angular/core';
import {NotesService} from '.././services/notes.service';
import * as jwt_decode from "jwt-decode";

@Component({
  selector: 'app-displaynotes',
  templateUrl: './displaynotes.component.html',
  styleUrls: ['./displaynotes.component.scss']
  
})
export class DisplaynotesComponent implements OnInit {
  constructor(private notes:NotesService) { }

  // token:any;
  // payLoad : any;
  // card = [];
  //  array:[]
  ngOnInit() {
  // this.token = localStorage.getItem('token')
  //  this.payLoad = jwt_decode(this.token)
  //  console.log(this.payLoad);
  //  this.getnotes();
  }
  // getnotes()
  // {
  //   this.notes.getNotes(this.payLoad.UserID).subscribe((data: any) => {
  //    this.card = data;
  //    console.log(this.card);
  //   })
  // }
}

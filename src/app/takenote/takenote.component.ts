import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import {NotesService} from '.././services/notes.service'
@Component({
  selector: 'app-takenote',
  templateUrl: './takenote.component.html',
  styleUrls: ['./takenote.component.scss']
})
export class TakenoteComponent implements OnInit {

  constructor(private service : NotesService) { }
  title = new FormControl('', [Validators.required, Validators.required]);
  description = new FormControl('', [Validators.required, Validators.required]);
  ngOnInit() {
  }
  
  AddNotes()
  {
    var data = {
      "title":this.title.value,
      "description":this.description.value,
      "email":localStorage.getItem('Email')
    }
    this.service.AddNotes(data).subscribe(data=>{
      console.log(data);
    },err=>{
      console.log(err);
      
    })

  }

}

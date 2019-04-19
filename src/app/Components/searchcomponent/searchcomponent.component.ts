import { Component, OnInit } from '@angular/core';
import { NotesService} from '../../services/NotesServices/notes.service'
import { DataserviceService } from 'src/app/services/Dataservice/dataservice.service';

@Component({
  selector: 'app-searchcomponent',
  templateUrl: './searchcomponent.component.html',
  styleUrls: ['./searchcomponent.component.scss']
})
export class SearchcomponentComponent implements OnInit {
userid:any;
  noteCards=[];
  cards:any;
  searchText:string=''
  constructor(private notes:NotesService,public data:DataserviceService) { }

  ngOnInit() {
    this.userid = localStorage.getItem("UserId")
    this.data.currentMessage.subscribe(response => {
      this.searchText=response;
      this.getallnotes()
      })
  }
  getallnotes()
  {
    this.notes.getNotes(this.userid).subscribe(data =>{
      console.log(data,"notes.ts");
      console.log()
      this.noteCards=[];
      this.cards=data[0].notesData;
      console.log(this.cards,"in serach");
    },err=>{
      console.log(err);
      
    })
  }

}

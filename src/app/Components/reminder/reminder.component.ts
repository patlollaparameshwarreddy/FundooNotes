import { Component, OnInit } from '@angular/core';
import { NotesService } from 'src/app/services/NotesServices/notes.service';

@Component({
  selector: 'app-reminder',
  templateUrl: './reminder.component.html',
  styleUrls: ['./reminder.component.scss']
})
export class ReminderComponent implements OnInit {
  userId:any
  reminderCards: any;
  constructor(private notes : NotesService) { 
    this.userId = localStorage.getItem("UserId");
  }

  ngOnInit() {
    this. remindercards()
  }
  remindercards(){
    console.log("archive");
    this.notes.reminderNotes(this.userId).subscribe(data =>{
      this.reminderCards=data["notesData"];
      console.log(this.reminderCards)
  },err =>{
    console.log(err);
  })
}
}

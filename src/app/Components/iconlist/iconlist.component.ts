import { Component, OnInit, Input, Output } from '@angular/core';
import { MatCard, MatDialogConfig, MatDialog } from '@angular/material';
import { NotesService } from 'src/app/services/NotesServices/notes.service';
import { EventEmitter } from '@angular/core';
import { CollaboratordialogComponent } from 'src/app/collaboratordialog/collaboratordialog.component';


@Component({
  selector: 'app-iconlist',
  templateUrl: './iconlist.component.html',
  styleUrls: ['./iconlist.component.scss']
})
export class IconlistComponent implements OnInit {
  getColor
  notesLabel: any;
  userId:any;
  email:any;
  userid:any;
  constructor(private notes:NotesService,private dialog: MatDialog) { 
    this.userId = localStorage.getItem('UserId')
    this.notes.getlabels(this.userId).subscribe(responselabels => {
      this.notesLabel = responselabels;
    },err=>{
      console.log(err);
    })
    this.userid = localStorage.getItem("UserId");
    this.email = localStorage.getItem("email");
  }
  @Input() card;
  @Input() type;
  @Output() update =new EventEmitter();
  @Output() setcolortoNote = new EventEmitter()
  ngOnInit() {
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

  Today(card)
  {
    var date = new Date();
    date.setHours(20,0,0)
    card.reminder = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate() + " " +  date.getHours() + ":" + ('0' + date.getMinutes())+ ":" + date.getSeconds();
    console.log(card.reminder,"todayyyy");
    this.notes.updateNotes(card).subscribe(data =>{
      console.log(data);
      this.update.emit({});
    },err =>{
      console.log(err);
    })
  }

  Tomorrow(card)
  {
    var date = new Date();
    date.setHours(8,0,0)
    card.reminder = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + (date.getDate()+1) + " " +  date.getHours() + ":" + ('0' +date.getMinutes()) + ":" + date.getSeconds();
    this.notes.updateNotes(card).subscribe(data =>{
      console.log(data);
      this.update.emit({});
    },err =>{
      console.log(err);
    })
  }

  nextWeek(card)
  {
    var date = new Date();
    date.setDate(date.getDate()+7);
    date.setHours(8,0,0)
    card.reminder = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + (date.getDate()) + " " +  date.getHours() + ":" + ('0' + date.getMinutes()) + ":" + date.getSeconds();  
    this.notes.updateNotes(card).subscribe(data =>{
      console.log(data);
      this.update.emit({});
    },err =>{
      console.log(err);
    })
  }

  openDialog(card): void {
    const dialogConfig = new MatDialogConfig();
    let dialogRef = this.dialog.open(CollaboratordialogComponent, {
      data:card
    });
    dialogRef.afterClosed().subscribe(result => {
      if(result != this.email)
      {
        this.notes.checkcollaborator(result).subscribe(data =>
          {
            console.log(data);
            var collaboratordata = {
             "UserId":this.userid,
             "NoteId":card.id,
             "SenderEmail":this.email,
             "ReceiverEmail":result
            }
            this.notes.addCollaboratorToNote(collaboratordata).subscribe(result =>
              {
                console.log(result);
                
              },err =>
              {
                console.log(err);
                
              })
          },err =>{
            console.log(err);
          })
      }
      else
      {
        console.log("invalid user");
        
      }
    });
  }

 
}

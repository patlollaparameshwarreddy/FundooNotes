import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { NotesService } from '../services/NotesServices/notes.service';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-collaboratordialog',
  templateUrl: './collaboratordialog.component.html',
  styleUrls: ['./collaboratordialog.component.scss']
})
export class CollaboratordialogComponent implements OnInit {
firstname:any
lastname:any
email:any
carddata:any
userId=localStorage.getItem("UserId");
  notesCollaborator: Object;
  constructor(public dialogRef: MatDialogRef<CollaboratordialogComponent>, private notes: NotesService,
    @Inject(MAT_DIALOG_DATA) public data: any) { 
     this.carddata = data;
    this.notes. getAllCollaboratedData(this.userId).subscribe(result =>{
      this.notesCollaborator = result;
    }, err => {
      console.log(err);
      
    })
    }
    userEmail = new FormControl('', [Validators.required, Validators.email]);
  ngOnInit() {
    this.firstname = localStorage.getItem("firstname");
    this.lastname = localStorage.getItem("lastname");
    this.email = localStorage.getItem("email");
  }
  checkemail()
  {
   console.log(this.userEmail.value);
   this.dialogRef.close(this.userEmail.value);
   
  }
  
}

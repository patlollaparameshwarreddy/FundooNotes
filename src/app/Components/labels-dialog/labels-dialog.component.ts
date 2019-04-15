import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormControl } from '@angular/forms';
import * as jwt_decode from "jwt-decode";
import { NotesService } from 'src/app/services/NotesServices/notes.service';

@Component({
  selector: 'app-labels-dialog',
  templateUrl: './labels-dialog.component.html',
  styleUrls: ['./labels-dialog.component.scss']
})
export class LabelsDialogComponent implements OnInit {
  notesLabel
  userId:any
  constructor(public dialogRef: MatDialogRef<LabelsDialogComponent>, private notes: NotesService,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

    labels = new FormControl('');
  ngOnInit() {
    this.notesLabel=this.data
  }
  close() {
    this.userId = localStorage.getItem('UserId')
    var data ={
      "labels":this.labels.value,
      "userId":this.userId
    }
    console.log(data);
    this.dialogRef.close(data);
  }
  update(label)
  {
    console.log(label.labels,"jgkldfgkdf");
    this.notes.updateLabel(label.id,label.labels).subscribe(result =>
      console.log(result)
      )
  }

  delete(label)
  {
    this.notes.deletelabel(label.id).subscribe(result =>
      console.log(result) )
  }

}

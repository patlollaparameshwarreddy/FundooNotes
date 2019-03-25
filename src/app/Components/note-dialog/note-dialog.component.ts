import { Component, OnInit,Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';

@Component({
  selector: 'app-note-dialog',
  templateUrl: './note-dialog.component.html',
  styleUrls: ['./note-dialog.component.scss']
})
export class NoteDialogComponent implements OnInit {

  constructor( public dialogRef: MatDialogRef<NoteDialogComponent>) { }

  ngOnInit() {
  } 
  onNoClick() {
    this.dialogRef.close();
  }

}

import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { NotesService } from '../services/NotesServices/notes.service';

@Component({
  selector: 'app-collaboratordialog',
  templateUrl: './collaboratordialog.component.html',
  styleUrls: ['./collaboratordialog.component.scss']
})
export class CollaboratordialogComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<CollaboratordialogComponent>, private notes: NotesService,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
  }

}

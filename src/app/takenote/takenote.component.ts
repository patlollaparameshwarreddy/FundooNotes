import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-takenote',
  templateUrl: './takenote.component.html',
  styleUrls: ['./takenote.component.scss']
})
export class TakenoteComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
  title = new FormControl('', [Validators.required, Validators.required]);
  description = new FormControl('', [Validators.required, Validators.required]);
}

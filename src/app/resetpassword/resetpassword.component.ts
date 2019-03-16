import { Component, OnInit } from '@angular/core';
import { Routes ,ActivatedRoute } from "@angular/router";
@Component({
  selector: 'app-resetpassword',
  templateUrl: './resetpassword.component.html',
  styleUrls: ['./resetpassword.component.scss']
})
export class ResetpasswordComponent implements OnInit {

  constructor(public activateRoute:ActivatedRoute) { }

  ngOnInit() {
  }
accessToken=this.activateRoute.snapshot.params.token;
}

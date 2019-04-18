import { Component, ChangeDetectorRef, OnDestroy } from '@angular/core';
import { MediaMatcher } from '@angular/cdk/layout';
import { SignoutService } from 'src/app/services/UserServices/signout.service';
import { NotesService } from 'src/app/services/NotesServices/notes.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatDialogConfig } from '@angular/material';
import { LabelsDialogComponent } from '../labels-dialog/labels-dialog.component';
import * as jwt_decode from "jwt-decode";
import { AppService } from 'src/app/services/UserServices/app.service';
import { Router } from '@angular/router'

@Component({
  selector: 'app-dash-board',
  templateUrl: './dash-board.component.html',
  styleUrls: ['./dash-board.component.scss']
})
export class DashBoardComponent implements OnDestroy {
  // tslint:disable-next-line: variable-name
  headName = "fundooNotes";
  private _mobileQueryListener: () => void;
  mobileQuery: MediaQueryList;
  shouldRun = [/(^|\.)plnkr\.co$/, /(^|\.)stackblitz\.io$/].some(h => h.test(window.location.host));
  notesLabel: any;
  token: string;
  payLoad: any;
  userid:any;
  email: string;
  value;
  selectedFile: File;
  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher, private user: AppService, private notes: NotesService, public router:Router ,public dialog: MatDialog) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    // tslint:disable-next-line: deprecation
    this.mobileQuery.addListener(this._mobileQueryListener);
    this.token = localStorage.getItem('token');
    this.payLoad = jwt_decode(this.token);
    this.notes.getlabels(this.payLoad.UserID).subscribe(responselabels => {
      this.notesLabel = responselabels;
      console.log(this.notesLabel)
    }, err => {
      console.log(err);
    })
  }

  // tslint:disable-next-line: use-life-cycle-interface
  ngOnInit() {
    this.islist = true;
    this.isClicked = false;
    this.email = localStorage.getItem("email")
  }
  islist;
  isClicked;
  changeview() {
    // debugger
    if (this.islist) {
      this.islist = false;
      console.log("list", this.islist);
      this.isClicked = true;
    }

    else {

      this.isClicked = false;
      console.log("grid", this.isClicked);
      this.islist = true;
    }
    this.notes.gridview();
  }

  lookfor(){

  }
  goSearch(){
    // this.router.navigate(['dashboard/search'])
  }

  ngOnDestroy(): void {
    // tslint:disable-next-line: deprecation
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }
  signout() {
    localStorage.clear();
  }
  isclick() {
    return false;
  }

  openDialog(): void {
    const dialogConfig = new MatDialogConfig();
    let dialogRef = this.dialog.open(LabelsDialogComponent, {
      width: '250px',
      data: this.notesLabel

    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result, "dash");
      if (result.labels != '' && result.labels != null) {
        this.notes.AddLabels(result).subscribe((data: any) => {
          console.log(data)
        }, err => {
          console.log(err);

        });
      }
    })
  }

  onFileChanged(event) {
    debugger;
    console.log(event);
    this.selectedFile = <File>event.target.files[0];
    console.log(this.selectedFile,"gjghj");
    let uploadData = new FormData();
    uploadData.append('file',this.selectedFile);
    console.log(uploadData,"dfsd");
    this.user.profilepic(uploadData,this.email).subscribe((data:any) => {
      console.log(data)
    },err =>{
      console.log(err);
    }
    );
  }

  
}

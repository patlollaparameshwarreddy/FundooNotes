import { Component,  ChangeDetectorRef, OnDestroy } from '@angular/core';
import { MediaMatcher } from '@angular/cdk/layout';
import { SignoutService } from 'src/app/services/UserServices/signout.service';
import { NotesService } from 'src/app/services/NotesServices/notes.service';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatDialogConfig} from '@angular/material';
import { LabelsDialogComponent } from '../labels-dialog/labels-dialog.component';

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
  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher, private service: SignoutService, private notes: NotesService,public dialog: MatDialog) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    // tslint:disable-next-line: deprecation
    this.mobileQuery.addListener(this._mobileQueryListener);
  }

  // tslint:disable-next-line: use-life-cycle-interface
  ngOnInit() {
    this.islist = true;
    this.isClicked = false;
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
    let dialogRef = this.dialog.open( LabelsDialogComponent, {
      width: '250px',
      
    });

    
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
}

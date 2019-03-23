import { Component, OnInit, ChangeDetectorRef, OnDestroy } from '@angular/core';
import { MediaMatcher } from '@angular/cdk/layout';
import {SignoutService } from '../services/signout.service'

@Component({
  selector: 'app-dash-board',
  templateUrl: './dash-board.component.html',
  styleUrls: ['./dash-board.component.scss']
})
export class DashBoardComponent  implements OnDestroy{
// tslint:disable-next-line: variable-name
private _mobileQueryListener: () => void;
mobileQuery: MediaQueryList;
shouldRun = [/(^|\.)plnkr\.co$/, /(^|\.)stackblitz\.io$/].some(h => h.test(window.location.host));
constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher,private service:SignoutService) {
this.mobileQuery = media.matchMedia('(max-width: 600px)');
this._mobileQueryListener = () => changeDetectorRef.detectChanges();
// tslint:disable-next-line: deprecation
this.mobileQuery.addListener(this._mobileQueryListener);
}

// tslint:disable-next-line: use-life-cycle-interface
ngOnInit() {
}
ngOnDestroy(): void {
// tslint:disable-next-line: deprecation
this.mobileQuery.removeListener(this._mobileQueryListener);
}
signout()
{
 localStorage.clear();
}
}

import { Component, ViewEncapsulation } from '@angular/core';
// import { MessagingService } from './shared/messaging.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {
  title = 'Fundoo';
  message;
constructor() { }
ngOnInit() {
  // this.messagingService.getPermission();
  // this.messagingService.receiveMessage()
  // this.message = this.messagingService.currentMessage
  }
  
}
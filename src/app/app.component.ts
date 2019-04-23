import { Component, ViewEncapsulation } from '@angular/core';
import { NotificationService } from './services/push_notification/notification.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {
  title = 'Fundoo';
  message;
  constructor(private messagingService: NotificationService) { }
  ngOnInit() {
  this.messagingService.getPermission();
  this.messagingService.receiveMessage()
  this.message = this.messagingService.currentMessage
  }
  
  
}

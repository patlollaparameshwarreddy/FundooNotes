
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs'
// import * as firebase from 'firebase/app';

import * as firebase from 'firebase';
import 'firebase/messaging';
import { NotesService } from '../NotesServices/notes.service';
@Injectable({
providedIn: 'root'
})
export class NotificationService {
    userid = localStorage.getItem("UserId");
    pushtoken:any
currentMessage = new BehaviorSubject(null);
messaging;
constructor(private note:NotesService) {

firebase.initializeApp({
'messagingSenderId': '1067607768713'
});
this.messaging = firebase.messaging();


}

/**
* request permission for notification from firebase cloud messaging
*
* @param userId userId
*/
getPermission() {
this.messaging.requestPermission()
.then(() => {
return this.messaging.getToken()
})
.then(token => {
console.log(token);
var data =
{
    "userId":this.userid,
    "PushToken":token
}
this.note.pushnotificationtoken(data).subscribe(data => {
    console.log(data)
},err =>
{
    console.log(err);
    
})
})
.catch((err) => {
console.log('Unable to get permission to notify.', err);
});
}
receiveMessage() {
this.messaging.onMessage((payload) => {
console.log("Message received. ", payload);
this.currentMessage.next(payload)
});
}
}

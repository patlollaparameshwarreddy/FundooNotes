
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs'
// import * as firebase from 'firebase/app';

import * as firebase from 'firebase';
import 'firebase/messaging';
@Injectable({
providedIn: 'root'
})
export class NotificationService {
currentMessage = new BehaviorSubject(null);
messaging;
constructor() {

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
console.log(token)
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

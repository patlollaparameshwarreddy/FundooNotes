import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import {NotesService} from './services/NotesServices/notes.service'


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
 
  constructor(private notesService: NotesService, private router:Router )
  {

  }

  canActivate() : boolean
  {
    if (this.notesService.loggedIn())
    {
      return true
    }
    else
    {
     this.router.navigate(['/login'])
     return false
    }
  }
}

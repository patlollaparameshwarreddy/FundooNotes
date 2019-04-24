import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { RegistrationComponent } from '../app/Components/registration/registration.component';
import { ForgetpasswordComponent } from '../app/Components/forgetpassword/forgetpassword.component';
import { AuthGuard } from '../app/auth.guard'
import { DashBoardComponent } from './Components/dash-board/dash-board.component';
import { DisplaynotesComponent } from './Components/displaynotes/displaynotes.component';
import { LoginComponent } from './Components/login/login.component';
import { NotesComponent } from './Components/notes/notes.component';
import { ResetpasswordComponent } from './Components/resetpassword/resetpassword.component';
import { IconlistComponent } from './Components/iconlist/iconlist.component';
import { NoteDialogComponent } from './Components/note-dialog/note-dialog.component';
import { ArchiveComponent } from './Components/archive/archive.component';
import { TrashComponent } from './Components/trash/trash.component';
import { ReminderComponent } from './Components/reminder/reminder.component';
import { LabelsDialogComponent } from './Components/labels-dialog/labels-dialog.component';
import { CollaboratordialogComponent } from './collaboratordialog/collaboratordialog.component';
import { SearchcomponentComponent } from './Components/searchcomponent/searchcomponent.component';
import { CollaboratedNotesComponent } from './Components/collaborated-notes/collaborated-notes.component';

const routes: Routes = [
  {
    path : '', component : LoginComponent
  },
  {
    path :'login', component : LoginComponent
  },
  {
    path :'Registration', component : RegistrationComponent
  },
 
  {
    path:'dashboard',
    component:DashBoardComponent,
    canActivate: [AuthGuard],
    children:[
      {
        path:'',
        redirectTo:'note',
        pathMatch:'full'
      },
      {
        path:'note',
       component:NotesComponent
      },
      {
        path:'displaynotes',
        component: DisplaynotesComponent
      },
      {
        path : 'archivenotes',
        component: ArchiveComponent
      },
      {
        path : 'trash',
        component : TrashComponent
      },
      {
        path : 'reminder',
        component: ReminderComponent
      },
      {
        path:'iconlist',
        component:IconlistComponent
      },
      {
        path:'note-dialog',
        component:NoteDialogComponent
      },
      {
        path:'label',
        component:LabelsDialogComponent
      },
      {
        path:'collaborator',
        component:CollaboratordialogComponent
      },
      {
        path:'search',
        component:SearchcomponentComponent
      },
      {
        path:'collaborator',
        component:CollaboratedNotesComponent
      }
    ]
  },
  {
    path:'forgetpassword',
    component:ForgetpasswordComponent
  },
  {
    path:'resetpassword',
    component:ResetpasswordComponent,
  }
  
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes),MatFormFieldModule],
  exports : [RouterModule]
})
export class AppRoutingModule { }

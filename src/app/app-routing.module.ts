import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { RegistrationComponent } from './registration/registration.component';
import { DashBoardComponent } from './dash-board/dash-board.component';
import { ForgetpasswordComponent } from './forgetpassword/forgetpassword.component';
import { ResetpasswordComponent } from './resetpassword/resetpassword.component';
import { TakenoteComponent } from './takenote/takenote.component';
import { NotesComponent } from './notes/notes.component';
import { DisplaynotesComponent } from './displaynotes/displaynotes.component';

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
    ]
  },
  {
    path:'forgetpassword',
    component:ForgetpasswordComponent
  },
  {
    path:'resetpassword',
    component:ResetpasswordComponent,
  },
  {
    path:'takenote',
    component:TakenoteComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes),MatFormFieldModule],
  exports : [RouterModule]
})
export class AppRoutingModule { }

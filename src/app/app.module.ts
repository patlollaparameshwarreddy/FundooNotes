import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {MatInputModule} from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCardModule, MatTableModule, MatFormFieldModule, MatDialogModule } from '@angular/material';
import {MatToolbarModule, MatToolbarRow} from '@angular/material/toolbar';
import { RouterModule } from '@angular/router';
import { RegistrationComponent } from '../app/Components/registration/registration.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { ForgetpasswordComponent } from '../app/Components/forgetpassword/forgetpassword.component';
import { HttpClientModule } from '@angular/common/http';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatIconModule,} from '@angular/material/icon';
import {MatListModule} from '@angular/material/list';
import {NgxToggleModule} from "ngx-toggle";
import {MatMenuModule} from '@angular/material/menu';
import { AuthGuard } from './auth.guard';
import { DashBoardComponent } from './Components/dash-board/dash-board.component';
import { DisplaynotesComponent } from './Components/displaynotes/displaynotes.component';
import { LoginComponent } from './Components/login/login.component';
import { IconlistComponent } from './Components/iconlist/iconlist.component';
import { NotesComponent } from './Components/notes/notes.component';
import { ResetpasswordComponent } from './Components/resetpassword/resetpassword.component';
import { TakenoteComponent } from './Components/takenote/takenote.component';
import { NoteDialogComponent } from './Components/note-dialog/note-dialog.component';
import { ArchiveComponent } from './Components/archive/archive.component';
import { TrashComponent } from './Components/trash/trash.component';
import { ReminderComponent } from './Components/reminder/reminder.component';
import { LabelsDialogComponent } from './Components/labels-dialog/labels-dialog.component';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatChipsModule} from '@angular/material/chips';
import { CollaboratordialogComponent } from './collaboratordialog/collaboratordialog.component';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    DashBoardComponent,
    ForgetpasswordComponent,
    ResetpasswordComponent,
    TakenoteComponent,
    NotesComponent,
    IconlistComponent,
    DisplaynotesComponent,
    NoteDialogComponent,
    ArchiveComponent,
    TrashComponent,
    ReminderComponent,
    LabelsDialogComponent,
    CollaboratordialogComponent,

   
  ],
  imports: [
    BrowserModule,   MatInputModule, MatButtonModule, MatCardModule, MatTableModule, MatFormFieldModule,
    AppRoutingModule,
    RouterModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    FormsModule,
    FlexLayoutModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    NgxToggleModule,
    MatMenuModule,
    MatDialogModule,
    MatCheckboxModule,
    MatChipsModule,
    
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }

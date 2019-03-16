import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import {MatInputModule} from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCardModule, MatTableModule, MatFormFieldModule } from '@angular/material';
import {MatToolbarModule} from '@angular/material/toolbar';
import { RouterModule } from '@angular/router';
import { RegistrationComponent } from './registration/registration.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { DashBoardComponent } from './dash-board/dash-board.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { ForgetpasswordComponent } from './forgetpassword/forgetpassword.component';
import { ResetpasswordComponent } from './resetpassword/resetpassword.component';
import { HttpClientModule } from '@angular/common/http';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatIconModule,} from '@angular/material/icon';
import {MatListModule} from '@angular/material/list';
import {NgxToggleModule} from "ngx-toggle";
import { TakenoteComponent } from './takenote/takenote.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    DashBoardComponent,
    ForgetpasswordComponent,
    ResetpasswordComponent,
    TakenoteComponent,

   
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
    NgxToggleModule
   
  

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

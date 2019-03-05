import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserService } from './Service/user.service';
import { FormsModule } from '@angular/forms';
import { HttpClientModule ,HTTP_INTERCEPTORS } from '@angular/common/http';
//import { UsersRoutingModule } from './users/users-routing.module';
import { UsersModule } from './users/users.module';
import { AuthGuard } from './auth/auth.guard';
import { AuthInterceptor } from './auth/auth.interceptor';
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    UsersModule
    , FormsModule,HttpClientModule
  ],
  providers: [UserService,AuthGuard
    ,{ provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }

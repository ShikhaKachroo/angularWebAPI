import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { ProfilecreationComponent } from './profilecreation/profilecreation.component';
import { LoginRegistrationPageComponent } from './login-registration-page/login-registration-page.component';
import { FormsModule } from '@angular/forms';
import { AuthGuard } from '../auth/auth.guard';
import { AuthInterceptor } from '../auth/auth.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

@NgModule({
  declarations: [LoginComponent, RegistrationComponent, ProfilecreationComponent, LoginRegistrationPageComponent],
  imports: [
    CommonModule,
    UsersRoutingModule,
    FormsModule
  ]

  // ,providers: [AuthGuard
  //   ,{ provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }]
})
export class UsersModule { }

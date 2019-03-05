import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProfilecreationComponent } from './profilecreation/profilecreation.component';
import { RegistrationComponent } from './registration/registration.component';
import { LoginRegistrationPageComponent } from './login-registration-page/login-registration-page.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from '../auth/auth.guard';
const routes: Routes = [
  { path: 'dash', component: ProfilecreationComponent,canActivate:[AuthGuard] },
  {
      path: 'register', component: LoginRegistrationPageComponent,
      children: [{ path: '', component: RegistrationComponent }]
  },
  {
      path: 'login', component: LoginRegistrationPageComponent,
      children: [{ path: '', component: LoginComponent }]
  },
  { path : '', redirectTo:'/login', pathMatch : 'full'}
  
//   { path: 'dash', component: ProfilecreationComponent },
//   // {    path: 'register', component: RegistrationComponent},
//   // {    path: 'login', component: LoginComponent},
//   {
//     path: 'users/register', component: LoginRegistrationPageComponent,
//     children: [{ path: '', component: RegistrationComponent }]
// },
// {
//     path: 'login', component: LoginRegistrationPageComponent,
//     children: [{ path: '', component: LoginComponent }]
// },
//   { path : 'users', redirectTo:'/users/register', pathMatch : 'full'}
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }

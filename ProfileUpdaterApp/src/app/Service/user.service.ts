import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams , HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../Models/User.model';
import { UserProfile } from '../Models/UserProfile.model';

@Injectable()
export class UserService {
   url="http://localhost:53723/api/";
  constructor(private httpClient: HttpClient,private router: Router) {}

  
submitRegister(registerUser: User): Observable<any> {
    return this.httpClient.post(this.url+
      'UserInfo/Register',registerUser
     );
  }
  // login(loginInfo: any) {

  //   this.httpClient
  //     .post('http://localhost:9999/users/login', loginInfo)
  //     .subscribe(
  //       data => {
  //         console.log(data);
  //         localStorage.setItem('token', data.toString());
  //         this.router.navigate(['/dash']);
  //       },
  //       error => {console.log(error)}
  //     );
  // }
  submitUserProfile(userProfile:UserProfile): Observable<any>{
    return this.httpClient
    .post(this.url+'UserProfile/InsertUserProfile', userProfile);
  }
  userAuthentication(user:User) {
    return this.httpClient
    .post(this.url+'User/Login', user);
  //       data => {
  //         console.log(data);
  //         localStorage.setItem('token', data.toString());
  //         this.router.navigate(['/dash']);
  //       },
  //       error => {console.log(error)}
  //     );
    // var data = "username=" + userName + "&password=" + password + "&grant_type=password";
    // var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded','No-Auth':'True' });
    // return this.httpClient.post('http://localhost:50393/' + 'token', data, { headers: reqHeader });
  }
  getUserClaims(){
    return  this.httpClient.get(this.url+'api/GetUserClaims');
   }
  // getUserName(): Observable<string>{
  //   return this.httpClient.get(
  //     'http://localhost:9999/users/username',
  //     {
  //       responseType: 'text',
  //       params: new HttpParams().append('token',localStorage.getItem('token'))
  //     }
  //   );
  // }
  getUserDetail(): Observable<string>{
    return this.httpClient.get(
      'http://localhost:9999/users/username',
      {
        responseType: 'text',
        params: new HttpParams().append('token',localStorage.getItem('token'))
      }
    );
  }
}

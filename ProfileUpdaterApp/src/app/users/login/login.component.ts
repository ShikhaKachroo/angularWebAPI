import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/Service/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { User } from 'src/app/Models/User.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
user:User=new User();;
  constructor(private userService: UserService, private router: Router,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() { }

  registerUser() {
    //this.router.navigate(['../main/register']);//, { relativeTo: this.activatedRoute }]);
    this.router.navigate(['../register']);
  }

  // login(userInfo) {
  //  console.log(userInfo);
  //  this.userService.login(userInfo);
  // }


  login(u, p) {
this.user.username=u;
this.user.password=p;
    this.userService.userAuthentication(this.user)
      .subscribe((data: any) => {
        //localStorage.setItem('userToken', data.uid);
        
        localStorage.setItem('uiid', data.result.uid);
        console.log(data.result.uid);
        this.router.navigate(['/dash']);
        //console.log(data.uid);
      },
        (err: HttpErrorResponse) => {
          console.log(err);
          // this.isLoginError = true;
        });;
    //console.log(userInfo);
    // this.userService.userAuthentication(u, p)
    //   .subscribe((data: any) => {
    //     localStorage.setItem('userToken', data.uid);
    //     // this.router.navigate(['/dash']);
    //     console.log(data.access_token);
    //   },
    //     (err: HttpErrorResponse) => {
    //       console.log(err);
    //       // this.isLoginError = true;
    //     });;
    // this.router.navigate(['/dash']);
  }

}

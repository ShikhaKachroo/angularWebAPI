import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/Service/user.service';
import { Router } from '@angular/router';
import { User } from 'src/app/Models/User.model';
import { UserInfo } from 'src/app/Models/UserInfo.model';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
user:User=new User();
//user.userinfo=new UserInfo();
  msg: string;
  constructor(private userService: UserService,private router: Router) {}
  register(registerUser) {
this.user.username=registerUser.username;
this.user.password=registerUser.password;
this.user.userinfo=new UserInfo();
this.user.userinfo.firstname=registerUser.firstname;
this.user.userinfo.lastname=registerUser.lastname;
this.user.userinfo.age=registerUser.age;
this.user.userinfo.dob=registerUser.dob;
this.user.userinfo.location=registerUser.location;

    //registerUser.User_CreatedDateTime=new Date();
    console.log(this.user);
    this.userService
      .submitRegister(this.user)
      .subscribe(
        data => (this.msg = 'Registered Successfully'),
        error => (this.msg = 'Error Generated')
      );
  }
  ngOnInit() {
  //  this.user=User;
  }
  loginPage() {
    //this.router.navigate(['../main/login']);
    this.router.navigate(['../login']);
  }

}

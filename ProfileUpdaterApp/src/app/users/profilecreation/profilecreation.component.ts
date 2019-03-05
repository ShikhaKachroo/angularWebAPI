import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/Service/user.service';
import { Router } from '@angular/router';
import { UserProfile } from 'src/app/Models/UserProfile.model';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-profilecreation',
  templateUrl: './profilecreation.component.html',
  styleUrls: ['./profilecreation.component.css']
})
export class ProfilecreationComponent implements OnInit {
userProfile:UserProfile=new UserProfile();
  username = '';
  userClaims: any;
  msg: string;
  constructor(private userService: UserService, private router: Router) {
    this.userService.getUserClaims().subscribe((data: any) => {
      console.log(data);
      this.userClaims = data;
 
    });
    // this.userService
    //   .getUserName()
    //   .subscribe(
    //     data => (this.username = data.toString()),
    //     error => this.router.navigate(['/main/login'])
    //   );
  }
  submitProfile(userInfo){
    this.userProfile.certificate=userInfo.certificate;
    this.userProfile.company=userInfo.company;
    this.userProfile.experience=userInfo.experience;
    this.userProfile.resume=userInfo.resume;
    this.userProfile.skills=userInfo.skills;
    this.userProfile.uiid=userInfo.uiid;
    this.userService
      .submitUserProfile(this.userProfile)
      .subscribe(
        data => (this.msg = 'Registered Successfully'),
        error => (this.msg = 'Error Generated')
      );
  }
  ngOnInit() {}
  logout() {
    localStorage.removeItem('userToken');
    //this.router.navigate(['/main/login']);
    this.router.navigate(['/login']);
  }

}

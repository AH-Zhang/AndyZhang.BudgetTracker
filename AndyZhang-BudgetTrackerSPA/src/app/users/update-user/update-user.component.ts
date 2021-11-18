import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { NewUser } from 'src/app/shared/models/NewUser';

@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
  styleUrls: ['./update-user.component.css']
})
export class UpdateUserComponent implements OnInit {

  updateUser: NewUser = {
    email: '',
    password: '',
    fullName: '',
    joinedOn: '',
  };
  userId: number = 0;
  joinOn: string = "";

  constructor(private userService: UserService,private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams
      .subscribe(params => {
        this.userId = params.userId;
        this.joinOn = params.joinDate;
      }
    );
  }

  updateSubmit(){
    this.updateUser.joinedOn = this.joinOn;
    this.userService.updateUser(this.updateUser, this.userId).subscribe(p => {
      this.router.navigateByUrl("/");
    });
  }
}

import { Component, OnInit } from '@angular/core';
import { NewUser } from 'src/app/shared/models/NewUser';
import { DatePipe } from '@angular/common';
import { UserService } from 'src/app/services/user.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {
  createUser: NewUser = {
    email: '',
    password: '',
    fullName: '',
    joinedOn: '',
  };

  constructor(private datePipe: DatePipe, private userService: UserService,private router: Router) { }

  ngOnInit(): void {
  }

  createSubmit(){
    this.createUser.joinedOn = this.datePipe.transform(new Date(),"yyyy-MM-dd")!.toString();
    this.userService.createUser(this.createUser).subscribe(p => {
      this.router.navigateByUrl("/");
    });
  }

}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/services/user.service'; 
import { User } from 'src/app/shared/models/User';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {
  userId: number = 0;
  user!: User;
  constructor(private userService: UserService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    // this.route.queryParams.subscribe(params => {this.userId = params.id});
    // console.log(this.userId)
    // this.route.paramMap.subscribe(p => {

        this.userService.getUser(this.userId).subscribe(
          m => { this.user = m;
            console.log("hello");
        });
    // });
    this.route.paramMap.subscribe(
      p => {
        this.userId = Number(p.get('id'));
        this.userService.getUser(this.userId).subscribe(
          u => {
            this.user = u;
          });
      }
    );
  }
}
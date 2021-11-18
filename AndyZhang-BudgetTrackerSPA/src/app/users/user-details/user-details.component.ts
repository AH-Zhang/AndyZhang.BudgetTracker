import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationExtras } from '@angular/router';
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

  ngOnInit() {
    this.route.queryParams
      .subscribe(params => {
        this.userId = params.userId;

        this.userService.getUser(this.userId).subscribe(u => {
          this.user = u;
        });
      }
    );
  }

  deleteIncome(id: number){
    this.userService.deleteIncome(id).subscribe(m => {
      location.reload();
    })
  }
  deleteExpenditure(id: number){
    this.userService.deleteExpenditure(id).subscribe(m => {
      location.reload();
    })
  }
}
import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { NewIncome } from 'src/app/shared/models/Income';

@Component({
  selector: 'app-create-income',
  templateUrl: './create-income.component.html',
  styleUrls: ['./create-income.component.css']
})
export class CreateIncomeComponent implements OnInit {
  createIncome: NewIncome = {
    userId: 0,
    amount: 0,
    description: '',
    incomeDate: '',
    remarks: ''
  };
  userId: number = 0;

  date: Date = new Date();
  
  constructor(private datePipe: DatePipe, private userService: UserService,private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams
      .subscribe(params => {
        this.userId = params.userId;
      }
    );
  }

  createSubmit(){
    this.createIncome.incomeDate = this.datePipe.transform(this.date,"yyyy-MM-dd")!.toString();
    this.createIncome.userId = this.userId;

    this.userService.createIncome(this.createIncome).subscribe(p => {
      this.router.navigateByUrl("/");
    });
  }
}

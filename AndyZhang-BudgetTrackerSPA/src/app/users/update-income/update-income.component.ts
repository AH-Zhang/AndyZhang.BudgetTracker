import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { NewIncome } from 'src/app/shared/models/Income';

@Component({
  selector: 'app-update-income',
  templateUrl: './update-income.component.html',
  styleUrls: ['./update-income.component.css']
})
export class UpdateIncomeComponent implements OnInit {

  updateIncome: NewIncome = {
    userId: 0,
    amount: 0,
    description: '',
    incomeDate: '',
    remarks: ''
  };
  userId: number = 0;
  id: number = 0;

  date: Date = new Date();
  
  constructor(private datePipe: DatePipe, private userService: UserService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams
      .subscribe(params => {
        this.userId = params.userId;
        this.id = params.id;
      }
    );
  }

  updateSubmit(){
    this.updateIncome.incomeDate = this.datePipe.transform(this.date,"yyyy-MM-dd")!.toString();
    this.updateIncome.userId = this.userId;
    console.log(this.id);
    this.userService.updateIncome(this.updateIncome, this.id).subscribe(p => {
      this.router.navigateByUrl("/");
    });
  }

}

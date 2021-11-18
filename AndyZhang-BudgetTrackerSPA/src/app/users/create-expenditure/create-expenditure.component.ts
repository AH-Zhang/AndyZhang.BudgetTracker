import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { NewExpenditure } from 'src/app/shared/models/Expenditure';

@Component({
  selector: 'app-create-expenditure',
  templateUrl: './create-expenditure.component.html',
  styleUrls: ['./create-expenditure.component.css']
})
export class CreateExpenditureComponent implements OnInit {

  createExpenditure: NewExpenditure = {
    userId: 0,
    amount: 0,
    description: '',
    expDate: '',
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
    this.createExpenditure.expDate = this.datePipe.transform(this.date,"yyyy-MM-dd")!.toString();
    this.createExpenditure.userId = this.userId;

    this.userService.createExpenditure(this.createExpenditure).subscribe(p => {
      this.router.navigateByUrl("/");
    });
  }

}

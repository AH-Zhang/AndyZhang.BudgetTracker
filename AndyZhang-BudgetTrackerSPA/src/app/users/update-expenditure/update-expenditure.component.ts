import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { NewExpenditure } from 'src/app/shared/models/Expenditure';

@Component({
  selector: 'app-update-expenditure',
  templateUrl: './update-expenditure.component.html',
  styleUrls: ['./update-expenditure.component.css']
})

export class UpdateExpenditureComponent implements OnInit {

  updateExpenditure: NewExpenditure = {
    userId: 0,
    amount: 0,
    description: '',
    expDate: '',
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
    this.updateExpenditure.expDate = this.datePipe.transform(this.date,"yyyy-MM-dd")!.toString();
    this.updateExpenditure.userId = this.userId;
    console.log(this.id);
    this.userService.updateExpenditure(this.updateExpenditure, this.id).subscribe(p => {
      this.router.navigateByUrl("/");
    });
  }

}

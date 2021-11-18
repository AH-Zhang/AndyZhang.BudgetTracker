import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateExpenditureComponent } from './update-expenditure.component';

describe('UpdateExpenditureComponent', () => {
  let component: UpdateExpenditureComponent;
  let fixture: ComponentFixture<UpdateExpenditureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateExpenditureComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateExpenditureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

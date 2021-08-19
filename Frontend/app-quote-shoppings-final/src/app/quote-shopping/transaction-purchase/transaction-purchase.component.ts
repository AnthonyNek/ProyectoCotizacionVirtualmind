import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';
import { FormControl, FormGroupDirective, FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}
@Component({
  selector: 'app-transaction-purchase',
  templateUrl: './transaction-purchase.component.html',
  styleUrls: ['./transaction-purchase.component.css']
})
export class TransactionPurchaseComponent implements OnInit {
  casesForm!: FormGroup;

  identificatorOfMoney = '';
  amount : number =  0;
  isLoadingResults = false;
  matcher = new MyErrorStateMatcher();
  constructor(private api:ApiService,private router:Router,private formBuilder:FormBuilder) { }

  ngOnInit(): void {
    this.casesForm = this.formBuilder.group({
      userid : [0, Validators.required],
      amount : [0, Validators.required],
      identificatorOfMoney : [null, Validators.required]
    
    });
  }
  onFormSubmit() {
    this.isLoadingResults = true;
    this.api.Save(this.casesForm.value)
      .subscribe((res: any) => {
          const id = res._id;
          this.isLoadingResults = false;
          this.router.navigate(["shopping"]);
        }, (err: any) => {
          console.log(err);
          this.isLoadingResults = false;
        });
        
  }
}

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';
import { CurrencyIdentifier } from '../models/CurrencyIdentifier';
import { ResultApi } from '../models/ResultApi';
@Component({
  selector: 'app-shopping',
  templateUrl: './shopping.component.html',
  styleUrls: ['./shopping.component.css']
})
export class ShoppingComponent implements OnInit {

  displayedColumns = ['AmountReal','AmountDolar'];
  isLoadingResults=true;
  resultApi: ResultApi = new ResultApi("");
  amountReal:string="";
  amountDolar:string="";
  currencyIdentifierArray: CurrencyIdentifier[] = [];
  constructor(public router:Router,private api:ApiService) { }
  ngOnInit(): void {

    this.api.GetQuote("Dolar").subscribe((res:ResultApi)=>{
     
      this.amountDolar=res.amount;
      this.isLoadingResults=false;;
    },err=>{
      console.log(err);
      this.isLoadingResults=false;
    })
    this.api.GetQuote("Real").subscribe((res:ResultApi)=>{
      this.amountReal=res.amount;
      this.isLoadingResults=false;
     
    },err=>{
      console.log(err);
      this.isLoadingResults=false;
    })

 }

 Refresh()  {
  this.isLoadingResults=true;
  this.api.GetQuote("Dolar").subscribe((res:ResultApi)=>{
     
    this.amountDolar=res.amount;
    this.isLoadingResults=false;;
  },err=>{
    console.log(err);
    this.isLoadingResults=false;
  })
  this.api.GetQuote("Real").subscribe((res:ResultApi)=>{
    this.amountReal=res.amount;
    this.isLoadingResults=false;
   
  },err=>{
    console.log(err);
    this.isLoadingResults=false;
  })

}
Buy()
{ 
  this.router.navigate(['mquoteshopping/quoteShopping/transactionPurchase']);
}
ReturnHome()
{ 
  this.router.navigate(['mquoteshopping/quoteShopping/quotes']);
}
}

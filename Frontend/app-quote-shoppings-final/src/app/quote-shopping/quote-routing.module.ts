import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { QuoteComponent } from './quote/quote.component';
import { ShoppingComponent } from './shopping/shopping.component';
import { TransactionPurchaseComponent } from './transaction-purchase/transaction-purchase.component';


const routes: Routes = [
  { path: '', redirectTo: 'quoteShopping/quotes', pathMatch: 'full'},
  { path: 'quoteShopping/quotes', component: QuoteComponent },{path:'quoteShopping/shopping',component:ShoppingComponent},
  {path:'quoteShopping/transactionPurchase',component:TransactionPurchaseComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class QuoteRoutingModule { }

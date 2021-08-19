import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'mquoteshopping', pathMatch: 'full'}, 
  { path: 'mquoteshopping', loadChildren: ()=>import('./quote-shopping/quote-shopping.module').then(m=>m.QuoteShoppingModule) },
  { path: '**', redirectTo: 'mquoteshopping' } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

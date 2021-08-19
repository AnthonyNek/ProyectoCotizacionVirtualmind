export class Shopping 
{
   userid:number ;
   amount:number ;
   identificatorOfMoney:string;
   constructor(userid:number,amount:number,identificatorOfMoney:string)
   { 
       this.userid =userid;
       this.amount =amount;
       this.identificatorOfMoney=identificatorOfMoney;
   }
}
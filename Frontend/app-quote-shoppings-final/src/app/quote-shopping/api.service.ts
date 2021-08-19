import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {catchError,tap} from 'rxjs/operators';
import {environment} from '../../environments/environment';
import {ResultApi} from './models/ResultApi';
import { Shopping } from './models/Shopping';
@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http:HttpClient) { }
  private readonly API_URL=environment.webAPI;
  headers={
    headers: new HttpHeaders({
      'Content-Type':'application/json'
    })
  }
  GetQuote(currencyIdentifier:string):Observable<ResultApi>{
    return this.http.get<ResultApi>(this.API_URL+"api/Quote/GetQuote/"+currencyIdentifier,this.headers).pipe(tap((data)=>{
      console.log(JSON.stringify(data));
    }),
      catchError(err=>{throw console.log('Error del servidor detalles'+JSON.stringify(err));})
    )
  }
  Save(shopping:Shopping):Observable<Response>{
    return this.http.post<Response>(this.API_URL+"Shopping​/Save",shopping,this.headers).pipe(tap((data)=>{
     alert(JSON.stringify(data));
   }),
   catchError(err=>{throw alert('Error del servidor detalles'+JSON.stringify(err));}),
   )
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { User } from '../_model/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:7249/api/'
  private currentUserSource = new BehaviorSubject<User | null>(null);
  userSource$ = this.currentUserSource.asObservable();
  constructor(public http: HttpClient) { }
  login(model:User){
    return this.http.post<User>(this.baseUrl + 'Account/Login', model).pipe(
      map((Response:User)=>{
        const res= Response;
        if(res){
          localStorage.setItem('user', JSON.stringify(res));
          this.currentUserSource.next(res);
        }
      })
    )
  }
  register(model:User){
    return this.http.post<User>(this.baseUrl + 'Account/Register', model).pipe(
      map((res)=>{
        if(res){
          localStorage.setItem('user', JSON.stringify(res));
          this.currentUserSource.next(res);
        }
        //return res;
      })
    )
  }

  setCurrentUser(user:User){
    this.currentUserSource.next(user);
  }
  logout(){
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }

}

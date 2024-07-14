import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { member } from '../_model/member';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class MenberService {
  apiurl = environment.apiUrl
  constructor(private http:HttpClient) { }

  getMembers(){
    return this.http.get<member[]>(this.apiurl+'user');
  }

  getMember(username:string){
    return this.http.get<member>(this.apiurl+'user/'+username);
  } 

  getHttpOptions(){
    const userString = localStorage.getItem('user');
    if(!userString) return;
    const user = JSON.parse(userString);
    return {
      headers : new HttpHeaders({
        Authorization : 'Bearer '+ user.token
      })
    }
  }


}

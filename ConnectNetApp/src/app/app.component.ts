import { Component, OnInit } from '@angular/core';
import { AccountService } from './service/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'ConnectNetApp';
  user:any;
  constructor(private service:AccountService){}
  ngOnInit(): void {
    this.setCurrentUser()
  }
  setCurrentUser(){
    const userstring=localStorage.getItem('user');
    if(!userstring) return;
    const User = JSON.parse(userstring);
    this.service.setCurrentUser(User);
  }
  
}

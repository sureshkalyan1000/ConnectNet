import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../service/account.service';
import { Observable, of } from 'rxjs';
import { User } from '../_model/user';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model:any = {};

  constructor(public acconutService:AccountService, private route:Router, private toast:ToastrService){}
  ngOnInit(): void {
  }
  
  login(){
    this.acconutService.login(this.model).subscribe({
      next : () => this.route.navigateByUrl('/members'),
      error : error => {this.toast.error(error.error);
        console.log(error)}
    })
  }
  logout(){
    this.acconutService.logout();
    this.route.navigateByUrl('/');
  }

}

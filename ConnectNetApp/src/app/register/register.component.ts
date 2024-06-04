import { Component, EventEmitter, Output } from '@angular/core';
import { AccountService } from '../service/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  model:any={};
  @Output() cancelRegister = new EventEmitter;
  constructor(private acc:AccountService, private toast:ToastrService){}
  register(){
    this.acc.register(this.model).subscribe({
      next: res => {console.log(res);
        this.cancel();
      },
      error: res => {this.toast.error(res.error);
        console.log(res)}
    })
    
  }
  cancel(){
    this.cancelRegister.emit(false);
  }
}

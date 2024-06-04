import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  
  registerMode:any=false
  registerToggle(){
    this.registerMode=true;
  }
  back(event:boolean){
    this.registerMode=event;
  }

}

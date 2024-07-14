import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { member } from 'src/app/_model/member';
import { MenberService } from 'src/app/service/menber.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
  
  members : any =[]
  constructor(private memberservice:MenberService){}
  ngOnInit(): void {
    this.memberservice.getMembers().subscribe({
      next : res => this.members= res,
      error : error => console.log(error)
    })
  }
}

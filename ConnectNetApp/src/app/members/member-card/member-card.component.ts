import { Component, Input, ViewEncapsulation } from '@angular/core';
import { member } from 'src/app/_model/member';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css'],
})
export class MemberCardComponent {
  @Input() member:member | undefined;

}

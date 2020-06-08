import {Component, Input, OnInit, Inject,} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
  selector: 'app-audit-popup',
  templateUrl: './audit-popup.component.html',
  styleUrls: ['./audit-popup.component.css']
})
export class AuditPopupComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
  }

  ngOnInit(): void {
    console.log(this.data);
  }
}

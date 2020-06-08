import {Component, Input, OnInit, Inject,} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
  selector: 'app-module-popup',
  templateUrl: './module-popup.component.html',
  styleUrls: ['./module-popup.component.css']
})
export class ModulePopupComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
  }

  ngOnInit(): void {
    console.log(this.data);
  }

}

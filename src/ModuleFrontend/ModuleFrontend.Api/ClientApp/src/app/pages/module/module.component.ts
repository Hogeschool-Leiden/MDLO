import { Component, OnInit } from '@angular/core';
import { Modulewijzer } from 'src/app/models/modulewijzer/modulewijzer';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-module',
  templateUrl: './module.component.html',
  styleUrls: ['./module.component.css']
})
export class ModuleComponent implements OnInit {
  modulewijzer: Modulewijzer;

  
  constructor() { }

  ngOnInit(): void {
  }

}

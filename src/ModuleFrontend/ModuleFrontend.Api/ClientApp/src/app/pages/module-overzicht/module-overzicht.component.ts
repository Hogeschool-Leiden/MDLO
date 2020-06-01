import { Component, OnInit } from '@angular/core';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-module-overzicht',
  templateUrl: './module-overzicht.component.html',
  styleUrls: ['./module-overzicht.component.css']
})
export class ModuleOverzichtComponent implements OnInit {

  constructor(private httpService: HttpService) { }

  ngOnInit(): void {
  }

}

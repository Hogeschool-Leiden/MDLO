import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-weather-main',
  templateUrl: './weather-main.component.html',
  styleUrls: ['./weather-main.component.css']
})
export class WeatherMainComponent implements OnInit {

  title = 'DE{BUG}LABS weather forcast';
  constructor() { }

  ngOnInit(): void {
  }

}

import {Component, OnInit} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';

@Component({
  selector: 'app-weather-info',
  templateUrl: './weather-info.component.html',
  styleUrls: ['./weather-info.component.css']
})
export class WeatherInfoComponent implements OnInit {

  // @ts-ignore
  weatherJson;

  constructor(private http: HttpClient) {
  }

  ngOnInit(): void {
    this.getWeatherData();
  }

  getWeatherData() {
    let httpObject;
    this.http.get('http://localhost/weatherforecast').subscribe(data => {
      httpObject = data;
      console.log(data);
      this.weatherJson = data;
    });
  }

  backgroundColor(weather) {
    if (weather.temperatureC > 30) {
      return '#FE0002';
    } else if (weather.temperatureC > 20) {
      return '#D80027';
    } else if (weather.temperatureC > 10) {
      return '#A1015D';
    } else if (weather.temperatureC > 0) {
      return '#63009E';
    } else if (weather.temperatureC > -10) {
      return '#2A00D5';
    } else if (weather.temperatureC > -25) {
      return '#0302FC';
    } else {
      return '#FFF';
    }
  }

  getIcon(weather) {
    if (weather.temperatureC > 10) {
      return 'wb_sunny';
    } else if (weather.temperatureC > 0) {
      return 'cloud';
    } else {
      return 'ac_unit';
    }
  }


}

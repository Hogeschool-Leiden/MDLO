import {Component, OnInit} from '@angular/core';
import {MatSliderChange} from "@angular/material/slider";
// @ts-ignore  its only mock-data
import mockJson from './../../assets/mock-data/mock-matrix-json.json';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-competencies',
  templateUrl: './competencies.component.html',
  styleUrls: ['./competencies.component.css']
})
export class CompetenciesComponent implements OnInit {
  year: number = 1;
  period: number = 1;
  specialisations: string[] = ['Propedeuse', 'Software Engineering', 'Interactie Technologie', 'Business Data Management', 'Forensiche ICT'];
  specialisation: string;
  sliderMin: number = 1;
  sliderMax: number = 3.75;
  showSlider: boolean = false;
  competenceMatrix;
  dbUrl:string = 'http://date.jsontest.com/';


  constructor(private http: HttpClient) {
  }

  updateSliderValue(event: MatSliderChange) {
    // removes decimals to create the years.
    this.year = Math.floor(event.value);

    // uses the decimals to create periods.
    switch (event.value - this.year) {
      case 0:
        this.period = 1;
        break;
      case 0.25:
        this.period = 2;
        break;
      case 0.50:
        this.period = 3;
        break;
      case 0.75:
        this.period = 4;
        break;
    }

  }

  specialisationChosen() {
    this.setSliderValues();
    this.showSlider = true;
  }

  setSliderValues() {
    if (this.isSpecialisationPropedeuse()) {
      this.sliderMin = 1;
      this.sliderMax = 1.50;
    } else {
      this.sliderMin = 1.75;
      this.sliderMax = 3.75;
    }
  }

  isSpecialisationPropedeuse() {
    return this.specialisation === 'Propedeuse';
  }

  getMatrixDataFromDB() {
    // this.http.get(this.dbUrl).toPromise().then(data => {
    //   this.competenceMatrix = data;
    // });
    // get from db but now use mock \/
    this.competenceMatrix = mockJson;
  }

  ngOnInit(){
  }
}
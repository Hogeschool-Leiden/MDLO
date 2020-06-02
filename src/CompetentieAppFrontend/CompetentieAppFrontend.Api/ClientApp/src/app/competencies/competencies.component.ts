import {Component, OnInit} from '@angular/core';
import {MatSliderChange} from "@angular/material/slider";
// @ts-ignore  its only mock-data
import mockJson from './../../assets/mock-data/eindcompetentie-mock.json';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-competencies',
  templateUrl: './competencies.component.html',
  styleUrls: ['./competencies.component.scss']
})
export class CompetenciesComponent implements OnInit {
  year: number = 1;
  period: number = 1;
  specialisations: string[] = ['Propedeuse', 'Software Engineering', 'Interactie Technologie', 'Business Data Management', 'Forensiche ICT'];
  specialisation: string;
  cohorts: string[] = [];
  cohort: string;
  firstYear: number = 2015;
  sliderMin: number = 1;
  sliderMax: number = 3.75;
  showSlider: boolean = false;
  amountOfPeriodsInYear: number = 4;
  amountOfPeriodsInPropedeuse: number = 3;
  competenceMatrix;
  dbPeriod: number;
  dbUrl: string;



  constructor(private http: HttpClient) {
  }

  updateSliderValue(sliderValue) {
    // removes decimals to create the years.
    this.year = Math.floor(sliderValue);

    // uses the decimals to create periods.
    switch (sliderValue - this.year) {
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
    // this gives dynamic url instead of the default.
    this.getPeriodeInDbFormat();


    // use db instead of mock
    // this.http.get(this.dbUrl).toPromise().then(data => {
    //   this.competenceMatrix = data;
    // });

    // mockdata instead of db
    this.competenceMatrix = mockJson;
  }

  getPeriodeInDbFormat() {
    if (this.isSpecialisationPropedeuse()) {
      this.dbPeriod = this.period;
    } else {
      // it removes the 3 propedeuse periods and converts years in 4 periods.
      this.dbPeriod = (this.year - 1) * this.amountOfPeriodsInYear - this.amountOfPeriodsInPropedeuse + this.period;
    }
    this.updateDbUrl();
  }

  updateDbUrl() {
    this.dbUrl = '/eindcompetentie/' + this.specialisation + '/' + this.dbPeriod + '/' + this.cohort;
  }

  getCohorts() {
    let year: number = this.getYearValue();

    while (year > this.firstYear) {
      let cohort = this.createCohort(year);
      this.cohorts.push(cohort);
      year = year - 1;
    }
    this.setCurrentCohort();
  }

  getYearValue() {
    return new Date().getFullYear() + 1;
  }

  createCohort(year) {
    return (year - 1).toString()+ '-' + year.toString();
  }

  setCurrentCohort() {
    this.cohort = this.cohorts[1];
  }

  ngOnInit() {
    this.getCohorts();
  }
}

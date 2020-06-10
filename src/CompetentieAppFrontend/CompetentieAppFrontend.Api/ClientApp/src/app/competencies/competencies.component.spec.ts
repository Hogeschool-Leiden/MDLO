import {async, ComponentFixture, fakeAsync, TestBed} from '@angular/core/testing';
import {CompetenciesComponent} from "./competencies.component";
import {ModulesComponent} from "../modules/modules.component";
import {CompetenceMatrixComponent} from "./competence-matrix/competence-matrix.component";
import {HttpClientModule} from "@angular/common/http";

describe('CompetenciesComponent', () => {
  let component: CompetenciesComponent;
  let fixture: ComponentFixture<CompetenciesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CompetenciesComponent, CompetenceMatrixComponent],
      imports: [HttpClientModule]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompetenciesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have proper custom slider values', function () {
    expect(component.year).toEqual(1);
    expect(component.period).toEqual(1);
    component.updateSliderValue(2.75);
    expect(component.year).toEqual(2);
    expect(component.period).toEqual(4);
  });

  it('should show slider after spec chosen', function () {
    expect(component.showSlider).toBeFalsy();
    component.specialisationChosen();
    expect(component.showSlider).toBeTruthy();
  });

  it('should calculate the correct period for the db', function () {
    component.specialisation = 'Software Engineering';
    component.updateSliderValue(2.75);
    component.getPeriodeInDbFormat();
    expect(component.dbPeriod).toEqual(5);
  });

  it('should say if specialisation is propedeuse', function () {
    component.specialisation = 'Propedeuse';
    expect(component.isSpecialisationPropedeuse).toBeTruthy();
  });

  it('should create the correct cohort.', function () {
    expect(component.createCohort(2019)).toEqual("2018-2019")
  });

  it('should return the current year + 1.', function () {
    let currentYear = new Date().getFullYear() + 1;

    expect(component.getYearValue()).toEqual(currentYear);
  });

  it('should see that specialisation is propedeuse or not.', function () {
    component.specialisation = 'Software Engineer';
    expect(component.isSpecialisationPropedeuse()).toBeFalsy();

    component.specialisation = 'Propedeuse';
    expect(component.isSpecialisationPropedeuse()).toBeTruthy();

  });

  it('should return the correct period based on de decimal value', function () {
    component.updateSliderValue(1.00);
    expect(component.period).toEqual(1);

    component.updateSliderValue(1.25);
    expect(component.period).toEqual(2);

    component.updateSliderValue(2.50);
    expect(component.period).toEqual(3);

    component.updateSliderValue(3.75);
    expect(component.period).toEqual(4);
  });

  it('should set slider min and max to 1 and 1.50 if you are in propedeuse', function () {
    component.specialisation = 'Propedeuse';
    component.setSliderValues();

    expect(component.sliderMin).toEqual(1);
    expect(component.sliderMax).toEqual(1.50);
  });

  it('should set the period to propedeuse period when db is requested.', function () {
    component.specialisation = 'Propedeuse';
    component.period = 1;

    component.getMatrixDataFromDB();

    expect(component.dbPeriod).toEqual(1);
  });


});

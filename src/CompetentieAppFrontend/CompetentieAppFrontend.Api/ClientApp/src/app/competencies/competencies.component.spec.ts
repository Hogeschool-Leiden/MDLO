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
      declarations: [ CompetenciesComponent , CompetenceMatrixComponent],
      imports:[HttpClientModule]
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
});

import {async, ComponentFixture, TestBed} from '@angular/core/testing';
import {DebugElement, SimpleChange} from "@angular/core";
import {By} from "@angular/platform-browser";
import {CompetenceMatrixComponent} from "./competence-matrix.component";
// @ts-ignore
import mockJson from './../../../assets/mock-data/eindcompetentie-mock.json';


describe('CompetenceMatrixComponent', () => {
  let component: CompetenceMatrixComponent;
  let fixture: ComponentFixture<CompetenceMatrixComponent>;
  let de: DebugElement;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CompetenceMatrixComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompetenceMatrixComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    de = fixture.debugElement;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should unhide the matrix.', function () {
    expect(component.showMatrix).toBeFalsy();
    component.specialisation = 'Software Engineering';
    component.competenceMatrix = mockJson;
    component.setupDisplayMatrix();
    expect(component.showMatrix).toBeTruthy();
  });

  it('Matrix should have headers', function () {
    component.specialisation = 'Software Engineering';
    component.competenceMatrix = mockJson;
    component.setupDisplayMatrix();
    expect(component.displayMatrix[0][1]).toEqual('analyseren');
    expect(component.displayMatrix[1][0]).toEqual('gebruikersinteractie');
  });

  it('matrix body should set values', function () {
    component.specialisation = 'Software Engineering';
    component.competenceMatrix = mockJson;
    component.setupDisplayMatrix();
    expect(component.displayMatrix[1][1]).toEqual(1);
    expect(component.displayMatrix[5][5]).toEqual(1);
  });

  it('reset matrix should put whole display matrix to nulls', function () {
    // fill it first
    component.specialisation = 'Software Engineering';
    component.competenceMatrix = mockJson;
    component.setupDisplayMatrix();
    expect(component.displayMatrix[1][1]).toEqual(1);
    expect(component.displayMatrix[5][5]).toEqual(1);

    //reset
    component.resetMatrix();
    expect(component.displayMatrix[1][1]).toEqual(null);
    expect(component.displayMatrix[5][5]).toEqual(null);
  });

  it('should return competence value', function () {
    let matrixElement1 = {value: 3}
    expect(component.getCorrectCompetenceValue(matrixElement1)).toEqual(3);

    let matrixElement2 = {value: {niveau: 2}}
    expect(component.getCorrectCompetenceValue(matrixElement2)).toEqual(2);

  });

  it('should return the correct colours to the correct competence value.', function () {
    expect(component.getCellColor('0')).toEqual('#FFF');
    expect(component.getCellColor('1')).toEqual('#88BFFF');
    expect(component.getCellColor('2')).toEqual('#2648FF');
    expect(component.getCellColor('3')).toEqual('#0000CA');
  });

});

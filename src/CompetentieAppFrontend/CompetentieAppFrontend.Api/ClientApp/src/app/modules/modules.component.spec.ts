import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import {ModulesComponent} from "./modules.component";
import {NO_ERRORS_SCHEMA} from "@angular/core";
import {CompetenceMatrixComponent} from "../competencies/competence-matrix/competence-matrix.component";
import {HttpClient, HttpClientModule} from "@angular/common/http";
// @ts-ignore
import moduleMock from "./../../assets/mock-data/modules-mock.json"

describe('ModuleComponent', () => {
  let component: ModulesComponent;
  let fixture: ComponentFixture<ModulesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModulesComponent , CompetenceMatrixComponent],
      imports:[HttpClientModule]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModulesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should clear Module Data', function () {
    component.MODULE_DATA.length = 3;

    component.clearModuleData();

    expect(component.MODULE_DATA.length).toEqual(0);

  });

  it('should remove columns if the screen is too small', function () {
    component.pageWidthInPixels = 1000;

    component.resizeTableToFitScreen();

    expect(component.displayedColumns.length).toEqual(4);
    expect(component.showEndRequirementsUnderMatrix).toEqual(true);
  });

  it('should add columns if the screen is big enough', function () {
    component.pageWidthInPixels = 1800;

    component.resizeTableToFitScreen();

    expect(component.displayedColumns.length).toEqual(5);
    expect(component.showEndRequirementsUnderMatrix).toEqual(false);
  });

  it('should inject data in the MODULE_DATA variable', function () {
    component.clearModuleData();
    component.moduleData = moduleMock;

    component.injectDataInTable();

    expect(component.MODULE_DATA.length).toEqual(3);
  });
});

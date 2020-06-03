import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import {ModulesComponent} from "./modules.component";
import {NO_ERRORS_SCHEMA} from "@angular/core";
import {CompetenceMatrixComponent} from "../competencies/competence-matrix/competence-matrix.component";
import {HttpClient, HttpClientModule} from "@angular/common/http";

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
});


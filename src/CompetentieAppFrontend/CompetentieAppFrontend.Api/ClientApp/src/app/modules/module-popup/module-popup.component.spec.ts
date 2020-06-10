import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModulePopupComponent } from './module-popup.component';
import {MAT_DIALOG_DATA} from "@angular/material/dialog";

describe('ModulePopupComponent', () => {
  let component: ModulePopupComponent;
  let fixture: ComponentFixture<ModulePopupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModulePopupComponent ],
      providers: [{provide: MAT_DIALOG_DATA, useValue: {}}]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModulePopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

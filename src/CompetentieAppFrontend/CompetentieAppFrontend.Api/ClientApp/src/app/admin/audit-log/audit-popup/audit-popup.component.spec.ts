import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AuditPopupComponent } from './audit-popup.component';
import {MAT_DIALOG_DATA} from "@angular/material/dialog";

describe('AuditPopupComponent', () => {
  let component: AuditPopupComponent;
  let fixture: ComponentFixture<AuditPopupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AuditPopupComponent ],
      providers: [{provide: MAT_DIALOG_DATA, useValue: {}}]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AuditPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

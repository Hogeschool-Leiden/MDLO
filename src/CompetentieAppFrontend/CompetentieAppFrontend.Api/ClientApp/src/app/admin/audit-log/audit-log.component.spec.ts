import {async, ComponentFixture, TestBed} from '@angular/core/testing';

import {AuditLogComponent} from './audit-log.component';
import {HttpClientModule} from "@angular/common/http";
import {MAT_DIALOG_DATA, MatDialog} from "@angular/material/dialog";
import {MatSort} from "@angular/material/sort";

describe('AuditLogComponent', () => {
  let component: AuditLogComponent;
  let fixture: ComponentFixture<AuditLogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [AuditLogComponent],
      imports: [HttpClientModule],
      providers: [{provide: MatDialog, useValue: {}}]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AuditLogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should  add data to the datasource.', function () {
    component.dataSource = undefined;

    expect(component.dataSource).toEqual(undefined);

    component.setDataSource();

    expect(component.dataSource).toBeTruthy();
  });

  it('should use the alternate data if alternate data is not undefined!', function () {
    component.alternateData = ['test', 'test'];

    component.checkWhatDataToUse();

    expect(component.auditData).toEqual(['test', 'test']);
  });

  it('should set the timestampsort.', function () {
    component.sort = new MatSort;

    component.setCorrectSortingOrder();

    expect(component.sort.active).toEqual('timestamp');
  });
});

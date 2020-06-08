import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModulePopupComponent } from './module-popup.component';

describe('ModulePopupComponent', () => {
  let component: ModulePopupComponent;
  let fixture: ComponentFixture<ModulePopupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModulePopupComponent ]
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

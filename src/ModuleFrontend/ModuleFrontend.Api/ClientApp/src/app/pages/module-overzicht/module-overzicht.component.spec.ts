import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModuleOverzichtComponent } from './module-overzicht.component';

describe('ModuleOverzichtComponent', () => {
  let component: ModuleOverzichtComponent;
  let fixture: ComponentFixture<ModuleOverzichtComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModuleOverzichtComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModuleOverzichtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

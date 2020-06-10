import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModulesInladenComponent } from './modules-inladen.component';

describe('ModulesInladenComponent', () => {
  let component: ModulesInladenComponent;
  let fixture: ComponentFixture<ModulesInladenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModulesInladenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModulesInladenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
});

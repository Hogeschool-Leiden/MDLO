import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModuleAanmakenComponent } from './module-aanmaken.component';

describe('ModuleAanmakenComponent', () => {
  let component: ModuleAanmakenComponent;
  let fixture: ComponentFixture<ModuleAanmakenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModuleAanmakenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModuleAanmakenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

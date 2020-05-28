import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModuleInformatieComponent } from './module-informatie.component';

describe('ModuleInformatieComponent', () => {
  let component: ModuleInformatieComponent;
  let fixture: ComponentFixture<ModuleInformatieComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModuleInformatieComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModuleInformatieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

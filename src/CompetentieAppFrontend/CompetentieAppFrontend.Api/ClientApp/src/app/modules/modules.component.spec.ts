import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import {DebugElement} from "@angular/core";
import {By} from "@angular/platform-browser";
import {ModulesComponent} from "./modules.component";
import {MatTableModule} from "@angular/material/table";

describe('ModulesComponent', () => {
  let component: ModulesComponent;
  let fixture: ComponentFixture<ModulesComponent>;
  let de: DebugElement;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModulesComponent],
      imports: [MatTableModule]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModulesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    de = fixture.debugElement;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { NavMenuComponent} from "./nav-menu.component";
import {DebugElement} from "@angular/core";
import {By} from "@angular/platform-browser";

describe('nav-menu component', () => {
  let component: NavMenuComponent;
  let fixture: ComponentFixture<NavMenuComponent>;
  let de: DebugElement;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavMenuComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    de = fixture.debugElement;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have a title of Opleiding Informatica', function () {
    expect(de.query(By.css('a')).nativeElement.innerText).toBe('Opleiding Informatica');
  });

  it('should have 3 buttons', function () {
    const EXPECTED_NUMBER_OF_BUTTONS:number = 2;
    let amountOfButtons:number = de.queryAll(By.css('.link-button')).length;
    expect(amountOfButtons).toEqual(EXPECTED_NUMBER_OF_BUTTONS);
  });
});

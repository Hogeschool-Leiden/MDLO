import {async, ComponentFixture, TestBed} from '@angular/core/testing';
import {NavMenuComponent} from "./nav-menu.component";
import {DebugElement} from "@angular/core";
import {By} from "@angular/platform-browser";
import {ModulesComponent} from "../modules/modules.component";
import {HttpClientModule} from "@angular/common/http";

describe('nav-menu component', () => {
  let component: NavMenuComponent;
  let fixture: ComponentFixture<NavMenuComponent>;
  let de: DebugElement;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [NavMenuComponent],
      imports: [HttpClientModule]
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
    const EXPECTED_NUMBER_OF_BUTTONS: number = 3;
    let amountOfButtons: number = de.queryAll(By.css('.link-button')).length;

    expect(amountOfButtons).toEqual(EXPECTED_NUMBER_OF_BUTTONS);
  });

  it('should be able to reverse the expanded booleon with the toggle method.', function () {
    component.isExpanded = true;

    component.toggle();

    expect(component.isExpanded).toBeFalsy();
  });

  it('should always put the expanded bool to false when collapse is called!', function () {
    component.isExpanded = true;

    component.collapse();

    expect(component.isExpanded).toBeFalsy();
  });
});

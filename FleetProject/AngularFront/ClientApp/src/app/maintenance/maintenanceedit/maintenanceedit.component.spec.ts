import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MaintenanceeditComponent } from './maintenanceedit.component';

describe('MaintenanceeditComponent', () => {
  let component: MaintenanceeditComponent;
  let fixture: ComponentFixture<MaintenanceeditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MaintenanceeditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MaintenanceeditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

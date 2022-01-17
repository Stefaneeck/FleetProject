import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleeditComponent } from './vehicleedit.component';

describe('VehicleeditComponent', () => {
  let component: VehicleeditComponent;
  let fixture: ComponentFixture<VehicleeditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicleeditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleeditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

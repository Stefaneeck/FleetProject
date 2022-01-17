import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicledetailComponent } from './vehicledetail.component';

describe('VehicledetailComponent', () => {
  let component: VehicledetailComponent;
  let fixture: ComponentFixture<VehicledetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicledetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicledetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

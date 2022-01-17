import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FuelcardeditComponent } from './fuelcardedit.component';

describe('FuelcardeditComponent', () => {
  let component: FuelcardeditComponent;
  let fixture: ComponentFixture<FuelcardeditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FuelcardeditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FuelcardeditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

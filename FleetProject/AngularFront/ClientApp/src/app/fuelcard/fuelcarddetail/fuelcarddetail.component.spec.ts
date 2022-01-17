import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FuelcarddetailComponent } from './fuelcarddetail.component';

describe('FuelcarddetailComponent', () => {
  let component: FuelcarddetailComponent;
  let fixture: ComponentFixture<FuelcarddetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FuelcarddetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FuelcarddetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FuelcardlistComponent } from './fuelcardlist.component';

describe('FuelcardlistComponent', () => {
  let component: FuelcardlistComponent;
  let fixture: ComponentFixture<FuelcardlistComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FuelcardlistComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FuelcardlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FuelcardaddComponent } from './fuelcardadd.component';

describe('FuelcardaddComponent', () => {
  let component: FuelcardaddComponent;
  let fixture: ComponentFixture<FuelcardaddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FuelcardaddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FuelcardaddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

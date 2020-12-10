import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddressdetailComponent } from './addressdetail.component';

describe('AddressdetailComponent', () => {
  let component: AddressdetailComponent;
  let fixture: ComponentFixture<AddressdetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddressdetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddressdetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

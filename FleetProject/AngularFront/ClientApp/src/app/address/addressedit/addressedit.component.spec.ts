import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddresseditComponent } from './addressedit.component';

describe('AddresseditComponent', () => {
  let component: AddresseditComponent;
  let fixture: ComponentFixture<AddresseditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddresseditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddresseditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

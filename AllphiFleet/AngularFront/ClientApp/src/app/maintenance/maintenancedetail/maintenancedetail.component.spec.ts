import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MaintenancedetailComponent } from './maintenancedetail.component';

describe('MaintenancedetailComponent', () => {
  let component: MaintenancedetailComponent;
  let fixture: ComponentFixture<MaintenancedetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MaintenancedetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MaintenancedetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

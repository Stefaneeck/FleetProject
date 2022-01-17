import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MaintenanceaddComponent } from './maintenanceadd.component';

describe('MaintenanceaddComponent', () => {
  let component: MaintenanceaddComponent;
  let fixture: ComponentFixture<MaintenanceaddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MaintenanceaddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MaintenanceaddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

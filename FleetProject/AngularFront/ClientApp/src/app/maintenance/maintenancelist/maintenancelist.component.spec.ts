import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MaintenancelistComponent } from './maintenancelist.component';

describe('MaintenancelistComponent', () => {
  let component: MaintenancelistComponent;
  let fixture: ComponentFixture<MaintenancelistComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MaintenancelistComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MaintenancelistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DrivereditComponent } from './driveredit.component';

describe('DrivereditComponent', () => {
  let component: DrivereditComponent;
  let fixture: ComponentFixture<DrivereditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DrivereditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DrivereditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

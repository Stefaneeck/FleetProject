import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationaddComponent } from './applicationadd.component';

describe('ApplicationaddComponent', () => {
  let component: ApplicationaddComponent;
  let fixture: ComponentFixture<ApplicationaddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApplicationaddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationaddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

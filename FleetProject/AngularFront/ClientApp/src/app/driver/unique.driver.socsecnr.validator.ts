import { FormBuilder, Validators, ValidationErrors, ValidatorFn, AbstractControl, AsyncValidator, FormControl } from '@angular/forms';
import { DriverService } from './driver.service';
import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class UniqueDriverSocSecNrValidator implements AsyncValidator {

  public initialValue: string;

  constructor(private driverService: DriverService) { }

  validate(
    ctrl: AbstractControl
  ): Promise<ValidationErrors | null> | Observable<ValidationErrors | null> {

    //when editing and not adding, the fields initial value should be ignored
    if (this.initialValue === ctrl.value) {
      return Promise.resolve(null);
    }

    return this.driverService.getDriverBySocSecNr(ctrl.value).pipe(
      //driverTaken will be referenced in driveradd.component.html
      map(driverId => (driverId !== 0 ? { driverTaken: true } : null)),
      catchError(() => of(null))
    );
  }
}



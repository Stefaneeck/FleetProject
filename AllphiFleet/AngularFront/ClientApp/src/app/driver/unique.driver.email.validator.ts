import { FormBuilder, Validators, ValidationErrors, ValidatorFn, AbstractControl, AsyncValidator, FormControl } from '@angular/forms';
import { DriverService } from './driver.service';
import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class UniqueDriverEmailValidator implements AsyncValidator {
  constructor(private driverService: DriverService) { }

  validate(
    ctrl: AbstractControl
  ): Promise<ValidationErrors | null> | Observable<ValidationErrors | null> {
    return this.driverService.getDriverByEmail(ctrl.value).pipe(
      map(driverId => (driverId !== 0 ? { driverEmailTaken: true } : null)),
      catchError(() => of(null))
    );
  }
}



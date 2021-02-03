import { FormBuilder, Validators, ValidationErrors, ValidatorFn, AbstractControl, AsyncValidator, FormControl } from '@angular/forms';
import { FuelcardService } from './fuelcard.service';
import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class UniqueFuelcardValidator implements AsyncValidator {
  constructor(private fuelcardService: FuelcardService) { }

  validate(
    ctrl: AbstractControl
  ): Promise<ValidationErrors | null> | Observable<ValidationErrors | null> {
    return this.fuelcardService.getFuelcardByCardNumber(ctrl.value).pipe(
      map(fuelCardId => (fuelCardId !== 0 ? { fuelcardTaken: true } : null)),
      catchError(() => of(null))
    );
  }
}



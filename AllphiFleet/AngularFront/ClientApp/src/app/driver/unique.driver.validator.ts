import { FormBuilder, Validators, ValidationErrors, ValidatorFn, AbstractControl } from '@angular/forms';
import { DriverService } from './driver.service';


export function checkDriverUniqueValidator(val: number, driverService: DriverService): ValidatorFn {

  return (control: AbstractControl): ValidationErrors | null => {

    let v: number = +control.value;

    if (isNaN(v)) {
      return { 'gte': true, 'requiredValue': val }
    }

    if (v <= +val) {
      return { 'gte': true, 'requiredValue': val }
    }

    return null;

  }

}

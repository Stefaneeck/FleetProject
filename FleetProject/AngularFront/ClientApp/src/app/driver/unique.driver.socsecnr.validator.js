"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
/*
export const uniqueDriverValidator = (driverService: DriverService ) =>
{
  console.log('te0');
  return (input: FormControl) => {
    console.log('te1');
    console.log(input.value);
    return driverService.getDriverBySocSecNr(input.value).pipe(
      map(driverId => (driverId !== 0 ? { uniqueDriver: true } : null)),
      catchError(() => of(null))
    );
  }
};
*/
/*
@Injectable({ providedIn: 'root' })
export class UniqueDriverValidator implements AsyncValidator {
  constructor(private driverService: DriverService) { }

  validate(
    ctrl: AbstractControl
  ): Promise<ValidationErrors | null> | Observable<ValidationErrors | null> {
    return this.driverService.getDriverBySocSecNr(ctrl.value).pipe(
      map(driverId => (driverId !== 0 ? { uniqueDriver: true } : null)),
      catchError(() => of(null))
    );
  }
}
*/
//# sourceMappingURL=unique.driver.validator.js.map
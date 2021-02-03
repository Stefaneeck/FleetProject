import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DriverService } from '../driver.service';
import { FormBuilder, Validators, ValidationErrors, ValidatorFn, AbstractControl, FormControl } from '@angular/forms';
import { IDriver } from '../../domain/IDriver';
import { EnumAuthenticationTypes } from '../../domain/enums/EnumAuthenticationTypes';
import { EnumDriverLicenseTypes } from '../../domain/enums/EnumDriverLicenseTypes';
import { UniqueDriverSocSecNrValidator } from '../unique.driver.socsecnr.validator';
import { UniqueDriverEmailValidator } from '../unique.driver.email.validator';
import { UniqueFuelcardValidator } from '../../fuelcard/unique.fuelcard.validator';


@Component({
  selector: 'app-driveradd',
  templateUrl: './driveradd.component.html',
  styleUrls: ['./driveradd.component.css', '../../shared/shared.css']
})
export class DriveraddComponent implements OnInit {

  errorMessage = "";
  driver: IDriver | undefined;
  driverForm: any;

  // Make a variable reference to our Enum
  //'remove' double values
  //keys are 0, 1, pin, pinkmstand
  enumAuthTypes = Object.keys(EnumAuthenticationTypes).filter(key => !isNaN(Number(EnumAuthenticationTypes[key])));
  enumDriverLicenseTypes = Object.keys(EnumDriverLicenseTypes).filter(key => !isNaN(Number(EnumDriverLicenseTypes[key])));

  constructor(private formBuilder: FormBuilder, private driverService: DriverService,
    private router: Router, private uniqueDriverSocSecNrValidator: UniqueDriverSocSecNrValidator,
    private uniqueDriverEmailValidator: UniqueDriverEmailValidator,
    private uniqueFuelcardValidator: UniqueFuelcardValidator) { }

  ngOnInit() {

    this.driverForm = this.formBuilder.group({
      //left column (first argument) = default value
      Name: ['', [Validators.required]],
      FirstName: ['', [Validators.required]],
      Email: ['', {
        validators: [Validators.required],
        asyncValidators: [this.uniqueDriverEmailValidator.validate.bind(this.uniqueDriverEmailValidator)],
        updateOn: 'blur'
      }],

      //nested group: address
      Address: this.formBuilder.group({ 
        Street: ['', [Validators.required]],
        Number: ['', [Validators.required]],
        City: ['', [Validators.required]],
        Zipcode: ['', [Validators.required]],
      }),

      BirthDate: ['', [Validators.required]],
      //set update on blur so we don't make an api call every time a character changes in the input box
      SocSecNr: ['', {
        validators: [Validators.required],
        asyncValidators: [this.uniqueDriverSocSecNrValidator.validate.bind(this.uniqueDriverSocSecNrValidator)],
        updateOn: 'blur'
      }],
      DriverLicenseType: [null, [Validators.required]],

      //nested group: fuelcard
      FuelCard: this.formBuilder.group({
        CardNumber: ['', {
          validators: [Validators.required],
          asyncValidators: [this.uniqueFuelcardValidator.validate.bind(this.uniqueFuelcardValidator)],
          updateOn: 'blur'
        }],
        ValidUntilDate: ['', [Validators.required]],
        Pincode: ['', [Validators.required]],
        AuthType: [null, [Validators.required]],
        Options: ['', [Validators.required]],
        //Not visible in html.Not being inputted by user, just default to true
        Active: [true, [Validators.required]]
      }),

      Active: [false, [Validators.required]]

    });
  }

  //nog op te lossen: als je actief niet op checked zet, dan geeft hij ipv false, "" mee aan de post request.
  //bij edit driver werkt dit nochtans wel.
  addDriver(): void {
    if (this.driverForm.valid) {
      console.log("valid.");

      const driverDataFromForm = this.driverForm.value;

      //convert to number, string was passed as value for option. "0" instead of 0
      driverDataFromForm.FuelCard.AuthType = Number(driverDataFromForm.FuelCard.AuthType);
      driverDataFromForm.DriverLicenseType = Number(driverDataFromForm.DriverLicenseType);

      this.driverService.addDriver(driverDataFromForm).subscribe({
        //next: result => this.driver = result,
        error: err => this.errorMessage = err,
        complete: () => {
          //doet hij enkel als er geen error is
          this.router.navigate(['/driverlist']);
        }
      });
    }
    else {
      console.log("not valid.");
      this.getFormValidationErrors();
    }
  }

  getFormValidationErrors() {
    Object.keys(this.driverForm.controls).forEach(key => {

      const controlErrors: ValidationErrors = this.driverForm.get(key).errors;
      if (controlErrors != null) {
        Object.keys(controlErrors).forEach(keyError => {
          console.log('Key control: ' + key + ', keyError: ' + keyError + ', err value: ', controlErrors[keyError]);
        });
      }
    });
  }

  onBack(): void {
    this.router.navigate(['/driverlist']);
  }

  checkDriverUniqueValidator(): ValidatorFn {

    //if everythings is fine, this returns null
    console.log('test0');
    return (control: AbstractControl): ValidationErrors | null => {
      let driverId: number;

      console.log('test1');

      console.log('control');
      console.log(control);

      if (control.value !== "") {

        return this.driverService.getDriverBySocSecNr(control.value).toPromise()
          .then((data: number) => {

            driverId = data;
            console.log('driverId');
            console.log(driverId);

            if (driverId === 0) {
              console.log('inside if');
              return { 'checkDriverUniqueValidator': true, 'requiredValue': control.value }
            }

            return null;

          }).catch((error) => {
            console.log("promise error");
            console.log(error);
          });
      }
    //only if errors at start
    return null;
  }

}


}

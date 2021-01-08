import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DriverService } from '../driver.service';
import { FormBuilder, Validators, ValidationErrors } from '@angular/forms';
import { IDriver } from '../../domain/IDriver';
import { EnumAuthenticationTypes } from '../../domain/enums/EnumAuthenticationTypes';
import { EnumDriverLicenseTypes } from '../../domain/enums/EnumDriverLicenseTypes';

@Component({
  selector: 'app-driveradd',
  templateUrl: './driveradd.component.html',
  styleUrls: ['./driveradd.component.css']
})
export class DriveraddComponent implements OnInit {

  errorMessage = "";
  driver: IDriver | undefined;
  driverForm: any;

  // Make a variable reference to our Enum
  //'dubbele' waarden verwijderen
  //keys zijn 0, 1, pin, pinkmstand
  enumAuthTypes = Object.keys(EnumAuthenticationTypes).filter(key => !isNaN(Number(EnumAuthenticationTypes[key])));
  enumDriverLicenseTypes = Object.keys(EnumDriverLicenseTypes).filter(key => !isNaN(Number(EnumDriverLicenseTypes[key])));

  constructor(private formBuilder: FormBuilder, private driverService: DriverService,
    private router: Router) { }

  ngOnInit() {

    this.driverForm = this.formBuilder.group({
      //left column (first argument) = default value
      Name: ['', [Validators.required]],
      FirstName: ['', [Validators.required]],

      //nested group: address
      Address: this.formBuilder.group({ 
        Street: ['', [Validators.required]],
        Number: ['', [Validators.required]],
        City: ['', [Validators.required]],
        Zipcode: ['', [Validators.required]],
      }),

      BirthDate: ['', [Validators.required]],
      SocSecNr: ['', [Validators.required]],
      DriverLicenseType: [null, [Validators.required]],

      //nested group: fuelcard
      FuelCard: this.formBuilder.group({
        CardNumber: ['', [Validators.required]],
        ValidUntilDate: ['', [Validators.required]],
        Pincode: ['', [Validators.required]],
        AuthType: [null, [Validators.required]],
        Options: ['', [Validators.required]],
      }),

      Active: [false, [Validators.required]]

    });
  }

  //nog op te lossen: als je actief niet op checked zet, dan geeft hij ipv false, "" mee aan de post request.
  //bij edit driver werkt dit nochtans wel.
  addDriver(driver: IDriver): void {
    if (this.driverForm.valid) {
      console.log("valid.");

      const driverDataFromForm = this.driverForm.value;

      //omzetten naar nummer, hij gaf string door als value voor de option "0" of "1" ipv 0 of 1
      driverDataFromForm.Tankkaart.AuthType = Number(driverDataFromForm.Tankkaart.AuthType);
      driverDataFromForm.TypeRijbewijs = Number(driverDataFromForm.TypeRijbewijs);

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
}

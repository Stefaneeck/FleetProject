import { Component, OnInit } from '@angular/core';
import { DriverService } from '../driver.service';
import { FormBuilder, Validators, ValidationErrors } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { formatDate } from '@angular/common';
import { IDriver } from '../../domain/IDriver';
import { EnumAuthenticationTypes } from '../../domain/enums/EnumAuthenticationTypes';
import { EnumDriverLicenseTypes } from '../../domain/enums/EnumDriverLicenseTypes';

@Component({
  selector: 'app-driveredit',
  templateUrl: './driveredit.component.html',
  styleUrls: ['./driveredit.component.css', '../../shared/shared.css']
})
export class DrivereditComponent implements OnInit {

  errorMessage = "";
  driver: IDriver | undefined;
  driverForm: any;
  pageTitle: string = 'Edit driver';

  //enum caused double values, remove double values to populate dropdown with good data
  enumAuthTypes = Object.keys(EnumAuthenticationTypes).filter(key => !isNaN(Number(EnumAuthenticationTypes[key])));
  enumDriverLicenseTypes = Object.keys(EnumDriverLicenseTypes).filter(key => !isNaN(Number(EnumDriverLicenseTypes[key])));

  constructor(private formBuilder: FormBuilder, private driverService: DriverService,
    private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {

    //get id from route parameter (sent here driverlist component)
    let id = +this.route.snapshot.paramMap.get('id');

    if (id) {
      this.getDriver(id);
      
    }

    this.pageTitle += `: ${id}`;
  }

  getDriver(id: number): void {
    //promise wordt gebruikt in vanilla js
    //subscribe kunnen we gebruiker met rxjs, promise vervangen door subscribe?
    const promise = this.driverService.getDriver(id).toPromise();

    //zeggen dat data een IDriver is
    //doet eigenlijk niets in JS, geen validatie. enkel met type unkown en dan 'bewijzen' dat het een IDriver is.
    promise.then((data:IDriver) => {

      this.driver = data;

      /*
      formulier hier pas aanmaken, in de then van de promise (dan hebben we de data)
      de naam voor het : komt overeen met de waarde van formControlName in het html formulier
      eerste argument is default value
      bvb Naam: [this.driver.Naam, [Validators.required]]


      we spreken hier het json object eigenlijk aan, we moeten zien dat onze domeinklasse de data ervan matcht. als we this.driver.Naam ipv this.driver.naam zouden gebruiken, zou het niet werken
      omdat het json object met kleine letters uit de api komt. we moeten dus hier de syntax van onze domeinklasse aanpassen aan hoe het in het json object zit, er wordt niets intern automatisch gemapt.
      */

      this.driverForm = this.formBuilder.group({
        Name: [this.driver.name, [Validators.required]],
        FirstName: [this.driver.firstName, [Validators.required]],
        Email: [this.driver.email, [Validators.required]],

        Address: this.formBuilder.group({
          Street: [this.driver.address.street, [Validators.required]],
          Number: [this.driver.address.number, [Validators.required]],
          City: [this.driver.address.city, [Validators.required]],
          Zipcode: [this.driver.address.zipcode, [Validators.required]],
        }),

        BirthDate: [formatDate(this.driver.birthDate, 'yyyy-MM-dd', 'en'), [Validators.required]],
        SocSecNr: [this.driver.socSecNr, [Validators.required]],
        DriverLicenseType: [this.driver.driverLicenseType, [Validators.required]],

        FuelCard: this.formBuilder.group({
          CardNumber: [this.driver.fuelCard.cardNumber, [Validators.required]],
          ValidUntilDate: [formatDate(this.driver.fuelCard.validUntilDate, 'yyyy-MM-dd', 'en'), [Validators.required]],
          Pincode: [this.driver.fuelCard.pincode, [Validators.required]],
          AuthType: [this.driver.fuelCard.authType, [Validators.required]],
          Options: [this.driver.fuelCard.options, [Validators.required]],
        }),

        Active: [this.driver.active, [Validators.required]]

      });

      //populate dropdowns with default values
      const stringValueDriverLicenseDropdown = this.driver.driverLicenseType.toString() + ": " + this.driver.driverLicenseType.toString();
      this.driverForm.controls['DriverLicenseType'].setValue(stringValueDriverLicenseDropdown, { onlySelf: true });
      const stringValueAuthTypeDropdown = this.driver.fuelCard.authType.toString() + ": " + this.driver.fuelCard.authType.toString();
      this.driverForm.controls['FuelCard'].controls['AuthType'].setValue(stringValueAuthTypeDropdown, { onlySelf: true });
      console.log(stringValueAuthTypeDropdown);


    }).catch((error) => {
      console.log("promise error");
      console.log(error);
    });
  }

  updateDriver(driver: IDriver): void {
    let driverDataFromForm = this.driverForm.value;

    //id manueel toevoegen
    driverDataFromForm.id = this.driver.id;

    //convert to number (angular was passing strings to the api)
    driverDataFromForm.FuelCard.AuthType = Number(driverDataFromForm.FuelCard.AuthType);
    driverDataFromForm.DriverLicenseType = Number(driverDataFromForm.DriverLicenseType);

    //fix voor wanneer je edit, en niet aan de checkbox kwam, stuurde hij NaN als waarde door
    if (isNaN(driverDataFromForm.FuelCard.AuthType)) {
      console.log("authtype NaN");
      driverDataFromForm.FuelCard.AuthType = this.driver.fuelCard.authType;
    }

    if (isNaN(driverDataFromForm.DriverLicenseType)) {
      console.log("driver license type NaN");
      driverDataFromForm.DriverLicenseType = this.driver.driverLicenseType;
    }

    if (this.driverForm.valid) {
      console.log("valid.");

      this.driverService.updateDriver(driverDataFromForm).subscribe({
        //info https://rxjs-dev.firebaseapp.com/guide/observer
      //Observers are just objects with three callbacks, one for each type of notification that an Observable may deliver. (next, error or complete)

      //next: result => this.driver = result,
        error: err => {
          this.errorMessage = err;
          console.log(this.errorMessage);
        },
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
}

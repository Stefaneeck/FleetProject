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
  styleUrls: ['./driveredit.component.css']
})
export class DrivereditComponent implements OnInit {

  errorMessage = "";
  driver: IDriver | undefined;
  driverForm: any;
  pageTitle: string = 'Edit driver';

  enumAuthTypes = Object.keys(EnumAuthenticationTypes).filter(key => !isNaN(Number(EnumAuthenticationTypes[key])));
  enumDriverLicenseTypes = Object.keys(EnumDriverLicenseTypes).filter(key => !isNaN(Number(EnumDriverLicenseTypes[key])));

  constructor(private formBuilder: FormBuilder, private driverService: DriverService,
    private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {

    let id = +this.route.snapshot.paramMap.get('id');

    if (id) {
      this.getDriver(id);
      
    }

    this.pageTitle += `: ${id}`;
  }

  getDriver(id: number): void {
    const promise = this.driverService.getDriver(id).toPromise();

    promise.then((data:IDriver) => {

      this.driver = data;

      this.driverForm = this.formBuilder.group({
        Naam: [this.driver.naam, [Validators.required]],
        Voornaam: [this.driver.voornaam, [Validators.required]],

        Adres: this.formBuilder.group({
          Straat: [this.driver.adres.straat, [Validators.required]],
          Nummer: [this.driver.adres.nummer, [Validators.required]],
          Stad: [this.driver.adres.stad, [Validators.required]],
          Postcode: [this.driver.adres.postcode, [Validators.required]],
        }),

        GeboorteDatum: [formatDate(this.driver.geboorteDatum, 'yyyy-MM-dd', 'en'), [Validators.required]],
        RijksRegisterNummer: [this.driver.rijksRegisterNummer, [Validators.required]],
        TypeRijbewijs: [this.driver.typeRijbewijs, [Validators.required]],

        Tankkaart: this.formBuilder.group({
          Kaartnummer: [this.driver.tankkaart.kaartnummer, [Validators.required]],
          GeldigheidsDatum: [formatDate(this.driver.tankkaart.geldigheidsDatum, 'yyyy-MM-dd', 'en'), [Validators.required]],
          Pincode: [this.driver.tankkaart.pincode, [Validators.required]],
          AuthType: [this.driver.tankkaart.authType, [Validators.required]],
          Opties: [this.driver.tankkaart.opties, [Validators.required]],
        }),

        Actief: [this.driver.actief, [Validators.required]]

      });
      
      const stringValue = this.driver.typeRijbewijs.toString() + ": " + (this.driver.typeRijbewijs).toString();
      this.driverForm.controls['TypeRijbewijs'].setValue(stringValue, { onlySelf: true });
      console.log("constructor");
      console.log(this.driver.typeRijbewijs);
      console.log(stringValue);

    }).catch((error) => {
      console.log("promise error");
    });
  }

  updateDriver(driver: IDriver): void {
    let driverDataFromForm = this.driverForm.value;

    driverDataFromForm.id = this.driver.id;


    driverDataFromForm.Tankkaart.AuthType = Number(driverDataFromForm.Tankkaart.AuthType);
    driverDataFromForm.TypeRijbewijs = Number(driverDataFromForm.TypeRijbewijs);

    if (this.driverForm.valid) {
      console.log("valid.");

      this.driverService.updateDriver(driverDataFromForm).subscribe({

        error: err => {
          this.errorMessage = err;
          console.log(this.errorMessage);
        },
        complete: () => {
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

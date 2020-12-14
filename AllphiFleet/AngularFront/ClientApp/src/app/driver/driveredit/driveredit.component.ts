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

  //dubbele waarden er uithalen voor dropdown te populeren met goede data, enum geeft dubbele binding
  enumAuthTypes = Object.keys(EnumAuthenticationTypes).filter(key => !isNaN(Number(EnumAuthenticationTypes[key])));
  enumDriverLicenseTypes = Object.keys(EnumDriverLicenseTypes).filter(key => !isNaN(Number(EnumDriverLicenseTypes[key])));

  constructor(private formBuilder: FormBuilder, private driverService: DriverService,
    private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {

    //id ophalen uit route parameter (naar hier gestuurd van driverlist componen
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
    //doet eigenlijk niets in JS, geen validatie ofzo. enkel met type unkown en dan 'bewijzen' dat het een IDriver is.
    promise.then((data:IDriver) => {

      this.driver = data;

      //formulier hier pas aanmaken, in de then van de promise (dan hebben we de data)
      //de naam voor het : komt overeen met de waarde van formControlName in het html formulier
      //eerste argument is default value
      //bvb Naam: [this.driver.Naam, [Validators.required]]


      //we spreken hier het json object eigenlijk aan, we moeten zien dat onze domeinklasse de data ervan matcht. als we this.driver.Naam ipv this.driver.naam zouden gebruiken, zou het niet werken
      //omdat het json object met kleine letters uit de api komt. we moeten dus hier de syntax van onze domeinklasse aanpassen aan hoe het in het json object zit, er wordt niets intern automatisch gemapt.

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

      //default values van dropdowns opvullen
      const stringValueDriverLicenseDropdown = this.driver.typeRijbewijs.toString() + ": " + this.driver.typeRijbewijs.toString();
      this.driverForm.controls['TypeRijbewijs'].setValue(stringValueDriverLicenseDropdown, { onlySelf: true });
      const stringValueAuthTypeDropdown = this.driver.tankkaart.authType.toString() + ": " + this.driver.tankkaart.authType.toString();
      this.driverForm.controls['Tankkaart'].controls['AuthType'].setValue(stringValueAuthTypeDropdown, { onlySelf: true });
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

    //omzetten naar number (hij gaf strings door aan de api)
    driverDataFromForm.Tankkaart.AuthType = Number(driverDataFromForm.Tankkaart.AuthType);
    driverDataFromForm.TypeRijbewijs = Number(driverDataFromForm.TypeRijbewijs);

    //fix voor wanneer je edit, en niet aan de checkbox kwam, stuurde hij NaN als waarde door
    if (isNaN(driverDataFromForm.Tankkaart.AuthType)) {
      console.log("authtype NaN");
      driverDataFromForm.Tankkaart.AuthType = this.driver.tankkaart.authType;
    }

    if (isNaN(driverDataFromForm.TypeRijbewijs)) {
      console.log("rijbewijs NaN");
      driverDataFromForm.TypeRijbewijs = this.driver.typeRijbewijs;
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

}

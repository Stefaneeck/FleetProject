import { Component, OnInit } from '@angular/core';
import { DriverService } from '../driver.service';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { formatDate } from '@angular/common';
import { IDriver } from '../../domain/IDriver';

@Component({
  selector: 'app-driveredit',
  templateUrl: './driveredit.component.html',
  styleUrls: ['./driveredit.component.css']
})
export class DrivereditComponent implements OnInit {

  errorMessage = "";
  //driver : IDriver | undefined
  driver: IDriver | undefined;
  driverForm: any;
  pageTitle: string = 'Edit driver';

  constructor(private formBuilder: FormBuilder, private driverService: DriverService,
    private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {

    //id ophalen uit route parameter (naar hier gestuurd van driverlist component)
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

        //nested group: adres
        Adres: this.formBuilder.group({
          Straat: [this.driver.adres.straat, [Validators.required]],
          Nummer: [this.driver.adres.nummer, [Validators.required]],
          Stad: [this.driver.adres.stad, [Validators.required]],
          Postcode: [this.driver.adres.postcode, [Validators.required]],
        }),

        //default value van date field invoeren werkt niet, formatDate gebruiken
        //GeboorteDatum: [this.driver.geboorteDatum, [Validators.required]],
        GeboorteDatum: [formatDate(this.driver.geboorteDatum, 'yyyy-MM-dd', 'en'), [Validators.required]],
        RijksRegisterNummer: [this.driver.rijksRegisterNummer, [Validators.required]],
        TypeRijbewijs: [this.driver.typeRijbewijs, [Validators.required]],

        //nested group: tankkaart
        Tankkaart: this.formBuilder.group({
          Kaartnummer: [this.driver.tankkaart.kaartnummer, [Validators.required]],
          GeldigheidsDatum: [formatDate(this.driver.tankkaart.geldigheidsDatum, 'yyyy-MM-dd', 'en'), [Validators.required]],
          Pincode: [this.driver.tankkaart.pincode, [Validators.required]],
          AuthType: [this.driver.tankkaart.authType, [Validators.required]],
          Opties: [this.driver.tankkaart.opties, [Validators.required]],
        }),

        Actief: [this.driver.actief, [Validators.required]]

      });

    }).catch((error) => {
      console.log("promise error");
    });
  }

  updateDriver(driver: IDriver): void {
    let driverDataFromForm = this.driverForm.value;
    //id manueel toevoegen
    driverDataFromForm.id = this.driver.id;

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

}

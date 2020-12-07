import { Component, OnInit } from '@angular/core';
import { DriverService } from '../driver.service';
import { IDriver } from '../driver';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

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

    const promise = this.driverService.getDriver(id).toPromise();

    //zeggen dat data een IDriver is
    promise.then((data:IDriver) => {

      this.driver = data;
      console.log('data output');
      console.log(this.driver);

      //formulier hier pas aanmaken, in de then van de promise (dan hebben we de data)
      //eerste argument is default value
      //bvb Naam: [this.driver.Naam, [Validators.required]]

      this.driverForm = this.formBuilder.group({
        Naam: [this.driver.naam, [Validators.required]],
        Voornaam: [this.driver.voornaam, [Validators.required]],

        //nested group: adres
        Adres: this.formBuilder.group({
          Straat: ['', [Validators.required]],
          Nummer: ['', [Validators.required]],
          Stad: ['', [Validators.required]],
          Postcode: ['', [Validators.required]],
        }),

        GeboorteDatum: ['', [Validators.required]],
        RijksRegisterNummer: ['', [Validators.required]],
        TypeRijbewijs: ['', [Validators.required]],

        //nested group: tankkaart
        Tankkaart: this.formBuilder.group({
          Kaartnummer: ['', [Validators.required]],
          GeldigheidsDatum: ['', [Validators.required]],
          Pincode: ['', [Validators.required]],
          AuthType: ['', [Validators.required]],
          Opties: ['', [Validators.required]],
        }),

        Actief: ['', [Validators.required]]

      });

      //default values instellen
      this.driverForm.get('Naam').setValue(this.driver.naam);

    }).catch((error) => {
      console.log("promise error");
    });
  }

}

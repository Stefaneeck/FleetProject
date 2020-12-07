import { Component, OnInit } from '@angular/core';
import { IDriver } from '../driver';
import { ActivatedRoute, Router } from '@angular/router';
import { DriverService } from '../driver.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-driveradd',
  templateUrl: './driveradd.component.html',
  styleUrls: ['./driveradd.component.css']
})
export class DriveraddComponent implements OnInit {

  errorMessage = "";
  //driver : IDriver | undefined
  driver: IDriver;
  driverForm: any;

  constructor(private formBuilder: FormBuilder, private route: ActivatedRoute,
    private driverService: DriverService, private router: Router) { }

  ngOnInit() {
    this.driverForm = this.formBuilder.group({
      Naam: ['', [Validators.required]],
      Voornaam: ['', [Validators.required]],

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
  }

  postDriver(driver: IDriver): void {
    const driverDataFromForm = this.driverForm.value;

    this.driverService.postDriver(driverDataFromForm).subscribe({
      //next: result => this.driver = result,
      error: err => this.errorMessage = err
    });
  }

}

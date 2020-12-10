import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DriverService } from '../driver.service';
import { FormBuilder, Validators } from '@angular/forms';
import { IDriver } from '../../domain/IDriver';

@Component({
  selector: 'app-driveradd',
  templateUrl: './driveradd.component.html',
  styleUrls: ['./driveradd.component.css']
})
export class DriveraddComponent implements OnInit {

  errorMessage = "";
  //driver : IDriver | undefined
  driver: IDriver | undefined;
  driverForm: any;

  constructor(private formBuilder: FormBuilder, private driverService: DriverService,
    private router: Router) { }

  ngOnInit() {

    this.driverForm = this.formBuilder.group({
      //linkse kolom waar nu '' staat, daar kan je default value instellen
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

  //nog op te lossen: als je actief niet op checked zet, dan geeft hij ipv false, "" mee aan de post request.
  //bij edit driver werkt dit nochtans wel.
  addDriver(driver: IDriver): void {
    if (this.driverForm.valid) {
      console.log("valid.");

      const driverDataFromForm = this.driverForm.value;

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
    }
  }
}

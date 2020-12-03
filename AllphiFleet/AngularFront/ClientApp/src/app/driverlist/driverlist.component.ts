import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-driverlist',
  templateUrl: './driverlist.component.html',
  styleUrls: ['./driverlist.component.css']
})
export class DriverlistComponent implements OnInit {
  public drivers: Driver[];
  public tempUrl: string = "https://localhost:44334/api/chauffeur";

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Driver[]>(this.tempUrl).subscribe(result => {
      this.drivers = result;
      //console.log(this.drivers);
    }, error => console.error(error));
    /*
    http.get<Driver[]>(baseUrl + 'drivers').subscribe(result => {
      this.drivers = result;
    }, error => console.error(error));
    */

    console.log(baseUrl + 'drivers');
  }
  ngOnInit(): void {

    throw new Error("Method not implemented.");
  }

}

interface Driver {

  id: number;
  naam: string;
  voorNaam: number;
  geboorteDatum: Date;
  rijksregisterNummer: number;
  typeRijbewijs: number;
  Actief: boolean;
  AdresId: number;
  TankkaartId: number;
  /*
  id: number;
  name: string;
  firstName: number;
  dateOfBirth: Date;
  SocialSecurityNumber: number;
  DriverLicenceType: number;
  Active: boolean;
  AddressId: number;
  GasCardId: number;
  */
}

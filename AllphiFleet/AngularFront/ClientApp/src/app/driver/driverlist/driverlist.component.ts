import { Component, OnInit, Inject } from '@angular/core';

import { DriverService } from '../driver.service';
import { IDriver } from '../../domain/IDriver';

@Component({
  selector: 'app-driverlist',
  templateUrl: './driverlist.component.html',
  styleUrls: ['./driverlist.component.css']
})
export class DriverlistComponent implements OnInit {

  public drivers: IDriver[];
  //public tempUrl: string = "https://localhost:44334/api/chauffeur";
  errorMessage = '';

  constructor(private driverService: DriverService) {

  }
    
  ngOnInit(): void {

    //casten naar IDriver in TS doet niets, is illusie van controle
    //drivers type unknown geven om validatie te kunnen uitvoeren, daarna dan tonen dat het een driver is

    //this in javascript is niet hetzelfde als in C#. Zolang het in lamdbas gebruikt wordt, is het ongeveer hetzelfde.
    //subscribe hoort bij rxjs (+- de linq van javascript)
    this.driverService.getDrivers().subscribe({
      next: drivers => {
        this.drivers = drivers;
        
      },
      error: err => this.errorMessage = err
    });
  }

  getDriverLicenseViewValue(enumValue: number): string {

    return this.driverService.showEnumValueDriverLicenseType(enumValue);
  }

}

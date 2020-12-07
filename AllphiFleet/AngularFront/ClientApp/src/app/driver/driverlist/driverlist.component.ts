import { Component, OnInit, Inject } from '@angular/core';

import { DriverService } from '../driver.service';
import { IDriver } from '../driver'

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

    this.driverService.getDrivers().subscribe({
      next: drivers => {
        this.drivers = drivers;
        //this.filteredProducts = this.products;
      },
      error: err => this.errorMessage = err
    });
  }

}

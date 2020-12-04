import { Component, OnInit, Inject } from '@angular/core';

import { DriverService } from './driver.service';
import { IDriver } from './driver'

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
    /*
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  
      http.get<Driver[]>(this.tempUrl).subscribe(result => {
      this.drivers = result;
      console.log(this.drivers);
    }, error => console.error(error));

    http.get<Driver[]>(baseUrl + 'drivers').subscribe(result => {
      this.drivers = result;
    }, error => console.error(error));
    

    console.log(baseUrl + 'drivers');
  }*/

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

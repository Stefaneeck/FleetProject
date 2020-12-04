import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DriverService } from '../driver.service';
import { IDriver } from '../driver';

@Component({
  selector: 'app-driverdetail',
  templateUrl: './driverdetail.component.html',
  styleUrls: ['./driverdetail.component.css']
})
export class DriverdetailComponent implements OnInit {
  pageTitle: string = 'Driver Detail';
  errorMessage = "";
  //driver : IDriver | undefined
  driver: IDriver;

  constructor(private route: ActivatedRoute, private driverService: DriverService, private router: Router) {
    //id variabele die we in url hebben meegegeven, id omdat we in app.module bij de route path: 'driver/:id' hebben gezet
    //snapshot gebruiken als we enkel de initieele waarde van de parameter nodig hebben, dan is het maar 1 lijn code. anders met observable.
    //als je verwacht dat de parameter van waarde verandert, zonder van pagina te veranderen, ook observable gebruiken.
  }

  ngOnInit() {
    let id = +this.route.snapshot.paramMap.get('id');

    //getDriver methode vanuit driver service rechtstreeks gebruiken?
    if (id) {
      this.getDriver(id);

    }
    this.pageTitle += `: ${id}`;
  }

  getDriver(id: number): void {
    this.driverService.getDriver(id).subscribe({
      next: result => this.driver = result,
      error: err => this.errorMessage = err
    });
  }

  onBack(): void {
    this.router.navigate(['/driverlist']);
  }

}

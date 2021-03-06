import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DriverService } from '../driver.service';
import { IDriver } from '../../domain/IDriver';

@Component({
  selector: 'app-driverdetail',
  templateUrl: './driverdetail.component.html',
  styleUrls: ['./driverdetail.component.css', '../../shared/shared.css']
})
export class DriverdetailComponent implements OnInit {

  pageTitle: string = 'Driver detail';
  errorMessage = "";
  //driver can be of type idriver or undefined
  driver: IDriver | undefined;

  constructor(private route: ActivatedRoute, private driverService: DriverService, private router: Router) {
    //id variabele die we in url hebben meegegeven, id omdat we in app.module bij de route path: 'driver/:id' hebben gezet
    //snapshot gebruiken als we enkel de initieele waarde van de parameter nodig hebben, dan is het maar 1 lijn code. anders met observable.
    //als je verwacht dat de parameter van waarde verandert, zonder van pagina te veranderen, ook observable gebruiken.
  }

  ngOnInit() {
    let id = +this.route.snapshot.paramMap.get('id');

    //if id is truthy
    if (id) {
      this.getDriver(id);
    }
    this.pageTitle += `: ${id}`;
  }

  getDriver(id: number): void {
    this.driverService.getDriver(id).subscribe({
      //put fetched value in local driver variable
      next: result => {
        this.driver = result;
      },
      error: err => this.errorMessage = err
    });
  }

  deleteDriver(id: number): void {
    this.driverService.deleteDriver(id).subscribe({

      error: err => {
        this.errorMessage = err;
        console.log("errormessage");
        console.log(this.errorMessage);
      },
      complete: () => {
        //only if no error, only does one of the three(?) (next, error of complete). (?)
        //next, error, complete
        //the first one to process the data which come with the event raised by the Observable
        //the second one to process any error if it occurs
        //the third one to do something on completion of the Observable

        /*
        The third argument of every sequence is the complete handler. It is invoked with no params and just notifies the sequence finished.

        Observable.from([1,3]).subscribe(
          (v => console.log('value: ', v)),
          (e => console.log('error: ', e)),
          (() => console.log('the sequence completed!'))

        would print:
        value: 1
        value: 2
        the sequence completed
         * */
        this.router.navigate(['/driverlist']);
      }
    });
    
  }

  getDriverLicenseViewValue(enumValue: number): string {

    return this.driverService.showEnumValueDriverLicenseType(enumValue);
  }

  onBack(): void {
    this.router.navigate(['/driverlist']);
  }

}

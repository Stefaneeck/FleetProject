import { Component, OnInit } from '@angular/core';
import { IApplication } from '../../domain/IApplication';
import { ActivatedRoute, Router } from '@angular/router';
import { ApplicationService } from '../application.service';
import { DriverService } from '../../driver/driver.service';
import { IDriver } from '../../domain/IDriver';

@Component({
  selector: 'app-applicationdetail',
  templateUrl: './applicationdetail.component.html',
  styleUrls: ['./applicationdetail.component.css']
})
export class ApplicationdetailComponent implements OnInit {

  pageTitle: string = 'Application detail';
  errorMessage = "";
  application: IApplication | undefined;
  driver: IDriver | undefined;

  constructor(private route: ActivatedRoute, private applicationService: ApplicationService,
    private driverService: DriverService, private router: Router, ) {

  }

  ngOnInit() {
    let id = +this.route.snapshot.paramMap.get('id');

    if (id) {
      this.getApplication(id);
      //this.getDriver(this.application.driver.id);
    }
    this.pageTitle += `: ${id}`;
  }

  getApplication(id: number): void {
    this.applicationService.getApplication(id).subscribe({
      next: result => {
        this.application = result;

        //added to get the applications driver
        this.getDriver(result.driver.id);
      },
      error: err => this.errorMessage = err
    });
  }

  deleteApplication(id: number): void {
    this.applicationService.deleteApplication(id).subscribe({

      error: err => {
        this.errorMessage = err;
        console.log("errormessage");
        console.log(this.errorMessage);
      },
      complete: () => {

        this.router.navigate(['/applicationlist']);
      }
    });

  }

  getApplicationStatusViewValue(enumValue: number): string {

    return this.applicationService.showEnumValueApplicationStatus(enumValue);
  }

  getApplicationTypeViewValue(enumValue: number): string {

    return this.applicationService.showEnumValueApplicationType(enumValue);
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

  onBack(): void {
    this.router.navigate(['/applicationlist']);
  }

}

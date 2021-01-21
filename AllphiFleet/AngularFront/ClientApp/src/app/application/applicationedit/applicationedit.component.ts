import { Component, OnInit } from '@angular/core';
import { IApplication } from '../../domain/IApplication';
import { EnumApplicationTypes } from '../../domain/enums/EnumApplicationTypes';
import { EnumApplicationStatuses } from '../../domain/enums/EnumApplicationStatuses';
import { FormBuilder, Validators, ValidationErrors } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApplicationService } from '../application.service';
import { IDriver } from '../../domain/IDriver';
import { IVehicle } from '../../domain/IVehicle';
import { DriverService } from '../../driver/driver.service';
import { VehicleService } from '../../vehicle/vehicle.service';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-applicationedit',
  templateUrl: './applicationedit.component.html',
  styleUrls: ['./applicationedit.component.css']
})
export class ApplicationeditComponent implements OnInit {

  errorMessage = "";
  application: IApplication | undefined;
  applicationForm: any;
  pageTitle: string = 'Edit application';
  drivers: IDriver[] | undefined;
  vehicles: IVehicle[] | undefined;

  //enum caused double values, remove double values to populate dropdown with good data
  enumApplicationTypes = Object.keys(EnumApplicationTypes).filter(key => !isNaN(Number(EnumApplicationTypes[key])));
  enumApplicationStatuses = Object.keys(EnumApplicationStatuses).filter(key => !isNaN(Number(EnumApplicationStatuses[key])));

  constructor(private formBuilder: FormBuilder, private applicationService: ApplicationService,
    private driverService: DriverService, private vehicleService: VehicleService,
    private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {

    let id = +this.route.snapshot.paramMap.get('id');

    if (id) {
      this.getApplication(id);
      
    }

    this.pageTitle += `: ${id}`;
  }

  getApplication(id: number): void {

    const promise = this.applicationService.getApplication(id).toPromise();

    promise.then((data: IApplication) => {

      this.application = data;

      //call this method after the application data arrives
      this.getDriversAndVehicles();

    }).catch((error) => {
      console.log("promise error");
      console.log(error);
    });
  }

  updateApplication(driver: IApplication): void {
    let applicationDataFromForm = this.applicationForm.value;

    applicationDataFromForm.id = this.application.id;

    applicationDataFromForm.ApplicationType = Number(applicationDataFromForm.ApplicationType);
    applicationDataFromForm.ApplicationStatus = Number(applicationDataFromForm.ApplicationStatus);

    if (isNaN(applicationDataFromForm.ApplicationType)) {
      console.log("applicationtype NaN");
      applicationDataFromForm.ApplicationType = this.application.applicationType;
    }

    if (isNaN(applicationDataFromForm.ApplicationStatus)) {
      console.log("applicationstatus NaN");
      applicationDataFromForm.ApplicationStatus = this.application.applicationStatus;
    }

    if (this.applicationForm.valid) {
      console.log("valid.");

      this.applicationService.updateApplication(applicationDataFromForm).subscribe({
        error: err => {
          this.errorMessage = err;
          console.log(this.errorMessage);
        },
        complete: () => {
          this.router.navigate(['/applicationlist']);
        }
      });

    }
    else {
      console.log("not valid.");
      this.getFormValidationErrors();
    }
  }

  getDriversAndVehicles(): void {

    const promiseDrivers = this.driverService.getDrivers().toPromise();

    promiseDrivers.then((dataDrivers: IDriver[]) => {

      this.drivers = dataDrivers;
      const promiseVehicles = this.vehicleService.getVehicles().toPromise();

      promiseVehicles.then((dataVehicles: IVehicle[]) => {

        this.vehicles = dataVehicles;

      });

      this.applicationForm = this.formBuilder.group({
        ApplicationDate: [formatDate(this.application.applicationDate, 'yyyy-MM-dd', 'en'), [Validators.required]],
        ApplicationType: [null, [Validators.required]],
        PossibleDates: [this.application.possibleDates, [Validators.required]],
        ApplicationStatus: [null, [Validators.required]],
        DriverId: [null, [Validators.required]],
        VehicleId: [null, [Validators.required]],
        Approved: [this.application.approved, [Validators.required]],

        //added to pass value to the api to be able to send mail
        //not visible in html
        Driver: this.formBuilder.group({
          Id: [this.application.driver.id],
          Name: [this.application.driver.name],
          FirstName: [this.application.driver.firstName],
          BirthDate: [this.application.driver.birthDate],
          SocSecNr: [this.application.driver.socSecNr],
          DriverLicenseType: [this.application.driver.driverLicenseType],
          Active: [this.application.driver.active],
          Email: [this.application.driver.email],
        }),
      });

      this.setDefaultValuesDropdowns();


    }).catch((error) => {
      console.log("promise error");
      console.log(error);
    });

  }

  setDefaultValuesDropdowns() {
    //default values for dropdowns
    const stringValueApplicationTypeDropdown = this.application.applicationType.toString() + ": " + this.application.applicationType.toString();
    this.applicationForm.controls['ApplicationType'].setValue(stringValueApplicationTypeDropdown, { onlySelf: true });

    const stringValueApplicationStatusDropdown = this.application.applicationStatus.toString() + ": " + this.application.applicationStatus.toString();
    this.applicationForm.controls['ApplicationStatus'].setValue(stringValueApplicationStatusDropdown, { onlySelf: true });

    this.applicationForm.controls['DriverId'].setValue(this.application.driver.id, { onlySelf: true });
    this.applicationForm.controls['VehicleId'].setValue(this.application.vehicle.id, { onlySelf: true });
  }

  getFormValidationErrors() {
    Object.keys(this.applicationForm.controls).forEach(key => {

      const controlErrors: ValidationErrors = this.applicationForm.get(key).errors;
      if (controlErrors != null) {
        Object.keys(controlErrors).forEach(keyError => {
          console.log('Key control: ' + key + ', keyError: ' + keyError + ', err value: ', controlErrors[keyError]);
        });
      }
    });
  }

}

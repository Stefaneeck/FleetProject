import { Component, OnInit } from '@angular/core';
import { IApplication } from '../../domain/IApplication';
import { EnumApplicationStatuses } from '../../domain/enums/EnumApplicationStatuses';
import { EnumApplicationTypes } from '../../domain/enums/EnumApplicationTypes';
import { ApplicationService } from '../application.service';
import { FormBuilder, Validators, ValidationErrors } from '@angular/forms';
import { Router } from '@angular/router';
import { DriverService } from '../../driver/driver.service';
import { IDriver } from '../../domain/IDriver';
import { VehicleService } from '../../vehicle/vehicle.service';
import { IVehicle } from '../../domain/IVehicle';

@Component({
  selector: 'app-applicationadd',
  templateUrl: './applicationadd.component.html',
  styleUrls: ['./applicationadd.component.css']
})
export class ApplicationaddComponent implements OnInit {

  errorMessage = "";
  application: IApplication | undefined;
  applicationForm: any;
  drivers: IDriver[] | undefined;
  vehicles: IVehicle[] | undefined;

  // Make a variable reference to our Enum and delete double values
  enumApplicationTypes = Object.keys(EnumApplicationStatuses).filter(key => !isNaN(Number(EnumApplicationStatuses[key])));
  enumApplicationStatuses = Object.keys(EnumApplicationTypes).filter(key => !isNaN(Number(EnumApplicationTypes[key])));

  constructor(private formBuilder: FormBuilder,
    private applicationService: ApplicationService,
    private driverService: DriverService,
    private vehicleService: VehicleService,
    private router: Router) {

  }

  ngOnInit() {

    this.getDriversAndVehicles();

  }

  addApplication(application: IApplication): void {
    if (this.applicationForm.valid) {
      console.log("valid.");

      const applicationDataFromForm = this.applicationForm.value;

      //convert to number, string was passed as value for option. "0" instead of 0
      applicationDataFromForm.ApplicationType = Number(applicationDataFromForm.ApplicationType);
      applicationDataFromForm.ApplicationStatus = Number(applicationDataFromForm.ApplicationStatus);

      this.applicationService.addApplication(applicationDataFromForm).subscribe({
        error: err => this.errorMessage = err,
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
        ApplicationDate: [null, [Validators.required]],
        ApplicationType: [null, [Validators.required]],
        PossibleDates: ['', [Validators.required]],
        ApplicationStatus: ['', [Validators.required]],
        DriverId: [null, [Validators.required]],
        VehicleId: [null, [Validators.required]],
      });



      //default values van dropdowns opvullen
      /*
      const stringValueDriverLicenseDropdown = this.driver.driverLicenseType.toString() + ": " + this.driver.driverLicenseType.toString();
      this.driverForm.controls['DriverLicenseType'].setValue(stringValueDriverLicenseDropdown, { onlySelf: true });
      const stringValueAuthTypeDropdown = this.driver.fuelCard.authType.toString() + ": " + this.driver.fuelCard.authType.toString();
      this.driverForm.controls['FuelCard'].controls['AuthType'].setValue(stringValueAuthTypeDropdown, { onlySelf: true });
      console.log(stringValueAuthTypeDropdown);
      */


    }).catch((error) => {
      console.log("promise error");
      console.log(error);
    });
    
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

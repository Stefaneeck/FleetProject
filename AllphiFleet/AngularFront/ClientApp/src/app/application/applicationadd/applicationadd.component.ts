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
import { IClaim } from '../../domain/IClaim';
import { AuthService } from '../../shared/services/auth.service';

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
  claims: any[] | undefined;
  isUserAdmin: boolean = false;

  // Make a variable reference to our Enum and delete double values
  enumApplicationStatuses = Object.keys(EnumApplicationStatuses).filter(key => !isNaN(Number(EnumApplicationStatuses[key])));
  enumApplicationTypes = Object.keys(EnumApplicationTypes).filter(key => !isNaN(Number(EnumApplicationTypes[key])));

  constructor(private formBuilder: FormBuilder,
    private applicationService: ApplicationService,
    private authService: AuthService,
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

    const errorHandler = (error) => {
      console.log("promise error");
      console.log(error);
    };

    this.driverService.getDrivers().toPromise().then((dataDrivers: IDriver[]) => {

      this.drivers = dataDrivers;
    }).catch(errorHandler);

    this.vehicleService.getVehicles().toPromise().then((dataVehicles: IVehicle[]) => {

      this.vehicles = dataVehicles;
    }).catch(errorHandler);

    this.driverService.getClaims().toPromise().then((dataClaims: any[]) => {

      this.isAdmin().then(() => {

        this.claims = dataClaims;

        //instantiate here, after getting the data
        this.applicationForm = this.formBuilder.group(Object.assign({
          ApplicationDate: [null, [Validators.required]],
          ApplicationType: [null, [Validators.required]],
          PossibleDates: ['', [Validators.required]],
          ApplicationStatus: ['', [Validators.required]],

          //todo: only vehicle of specific driver
          //at this moment no link between driver and vehicle, add?
          VehicleId: [null, [Validators.required]]
        }, this.isUserAdmin ? { DriverId: [null] } : { DriverEmail: [this.claims.filter(claim => claim.type === "email")[0].value] }));

        console.log('test2');
        console.log(this.isUserAdmin);
      });
    }).catch(errorHandler);
  }

  /*getDriversAndVehicles(): void {
    //+- same as above, but this is not the best way to do it (less control)
    //use when you want to do something after ALL promises arrive, for instance (you can call .then after .all)
    //create 1 promise out of 3 promises, and catch after
    //promise.all = after all arrive
    //promise.any = after the first arrives..
    Promise.all([
      this.driverService.getDrivers().toPromise().then((dataDrivers: IDriver[]) => {

        this.drivers = dataDrivers;
      }),

      this.vehicleService.getVehicles().toPromise().then((dataVehicles: IVehicle[]) => {

        this.vehicles = dataVehicles;
      }),

      this.driverService.getClaims().toPromise().then((dataClaims: any[]) => {

        this.isAdmin().then(() => {

          this.claims = dataClaims;

          //instantiate here, after getting the data
          this.applicationForm = this.formBuilder.group(Object.assign({
            ApplicationDate: [null, [Validators.required]],
            ApplicationType: [null, [Validators.required]],
            PossibleDates: ['', [Validators.required]],
            ApplicationStatus: ['', [Validators.required]],

            //todo: only vehicle of specific driver
            //at this moment no link between driver and vehicle, add?
            VehicleId: [null, [Validators.required]]
          }, this.isUserAdmin ? { DriverId: [null] } : { DriverEmail: [this.claims.filter(claim => claim.type === "email")[0].value] }));

          console.log('test2');
          console.log(this.isUserAdmin);
        });
      })

    ]).catch((error) => {
      console.log("promise error");
      console.log(error);
    });
  }
  */

  /*
   * getDriversAndVehicles(): void {

    const promiseDrivers = this.driverService.getDrivers().toPromise();

    promiseDrivers.then((dataDrivers: IDriver[]) => {

      this.drivers = dataDrivers;
      return this.vehicleService.getVehicles().toPromise();

    }).then((dataVehicles: IVehicle[]) => {

      this.vehicles = dataVehicles;
      return this.driverService.getClaims().toPromise();

    }).then((dataClaims: any[]) => {

      this.isAdmin().then(() => {

        this.claims = dataClaims;

        //instantiate here, after getting the data
        this.applicationForm = this.formBuilder.group(Object.assign({
          ApplicationDate: [null, [Validators.required]],
          ApplicationType: [null, [Validators.required]],
          PossibleDates: ['', [Validators.required]],
          ApplicationStatus: ['', [Validators.required]],

          //todo: only vehicle of specific driver
          //at this moment no link between driver and vehicle, add?
          VehicleId: [null, [Validators.required]]
        }, this.isUserAdmin ? { DriverId: [null] } : { DriverEmail: [this.claims.filter(claim => claim.type === "email")[0].value] }));

        console.log('test2');
        console.log(this.isUserAdmin);
      });


    }).catch((error) => {
      console.log("promise error");
      console.log(error);
    });

  }
   */

  /*getDriversAndVehicles(): void {

    const promiseDrivers = this.driverService.getDrivers().toPromise();

    promiseDrivers.then((dataDrivers: IDriver[]) => {

      this.drivers = dataDrivers;
      const promiseVehicles = this.vehicleService.getVehicles().toPromise();

      promiseVehicles.then((dataVehicles: IVehicle[]) => {

        this.vehicles = dataVehicles;
        const promiseClaims = this.driverService.getClaims().toPromise();

        promiseClaims.then((dataClaims: any[]) => {

          this.claims = dataClaims;
          console.log('email');
          console.log(this.claims);

          //instantiate here, after getting the data

          this.applicationForm = this.formBuilder.group({
            ApplicationDate: [null, [Validators.required]],
            ApplicationType: [null, [Validators.required]],
            PossibleDates: ['', [Validators.required]],
            ApplicationStatus: ['', [Validators.required]],

            //driver id should be replaced. The logged in driver who creates the application should automatically be the id, it should not explicitly be added
            //not visible in html
            DriverEmail: [this.claims.filter(claim => claim.type === "email")[0].value, [Validators.required]],
            //todo: only vehicle of specific driver
            //at this moment no link between driver and vehicle, add?
            VehicleId: [null, [Validators.required]]
          });
        });

      });

    }).catch((error) => {
      console.log("promise error");
      console.log(error);
    });

  } */

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

  public isAdmin = () => {
    return this.authService.checkIfUserIsAdmin()
      .then(res => {
        this.isUserAdmin = res;

        console.log('admin?');
        console.log(res);
      })
  }

  onBack(): void {
    this.router.navigate(['/applicationlist']);
  }
}

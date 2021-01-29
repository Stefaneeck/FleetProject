import { Component, OnInit } from '@angular/core';
import { IVehicle } from '../../domain/IVehicle';
import { FormBuilder, Validators } from '@angular/forms';
import { VehicleService } from '../vehicle.service';
import { ActivatedRoute, Router } from '@angular/router';
import { EnumVehicleTypes } from '../../domain/enums/EnumVehicleTypes';
import { EnumFuelTypes } from '../../domain/enums/EnumFuelTypes';

@Component({
  selector: 'app-vehicleedit',
  templateUrl: './vehicleedit.component.html',
  styleUrls: ['./vehicleedit.component.css', '../../shared/shared.css']
})
export class VehicleeditComponent implements OnInit {

  errorMessage = "";
  vehicle: IVehicle | undefined;
  vehicleForm: any;
  pageTitle: string = 'Edit vehicle';

  //enum caused double values, remove double values to populate dropdown with good data
  enumVehicleTypes = Object.keys(EnumVehicleTypes).filter(key => !isNaN(Number(EnumVehicleTypes[key])));
  enumFuelTypes = Object.keys(EnumFuelTypes).filter(key => !isNaN(Number(EnumFuelTypes[key])));

  constructor(private formBuilder: FormBuilder, private vehicleService: VehicleService,
    private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    let id = +this.route.snapshot.paramMap.get('id');

    if (id) {
      this.getVehicle(id);
    }

    this.pageTitle += `: ${id}`;
  }

  getVehicle(id: number): void {
    const promise = this.vehicleService.getVehicle(id).toPromise();

    promise.then((data: IVehicle) => {

      this.vehicle = data;

      this.vehicleForm = this.formBuilder.group({

        ChassisNr: [this.vehicle.chassisNr, [Validators.required]],
        FuelType: [this.vehicle.fuelType, [Validators.required]],
        VehicleType: [this.vehicle.vehicleType, [Validators.required]],
        Mileage: [this.vehicle.mileage, [Validators.required]]
      });

      //populate dropdowns with default values
      const stringValueVehicleTypeDropdown = this.vehicle.vehicleType.toString() + ": " + this.vehicle.vehicleType.toString();
      this.vehicleForm.controls['VehicleType'].setValue(stringValueVehicleTypeDropdown, { onlySelf: true });
      const stringValueFuelTypeDropdown = this.vehicle.fuelType.toString() + ": " + this.vehicle.fuelType.toString();
      this.vehicleForm.controls['FuelType'].setValue(stringValueFuelTypeDropdown, { onlySelf: true });

    }).catch((error) => {
      console.log("promise error");
    });
  }

  updateVehicle(vehicle: IVehicle): void {
    let vehicleDataFromForm = this.vehicleForm.value;
    //add id manually
    vehicleDataFromForm.id = this.vehicle.id;

    vehicleDataFromForm.VehicleType = Number(vehicleDataFromForm.VehicleType);
    vehicleDataFromForm.FuelType = Number(vehicleDataFromForm.FuelType);


    if (this.vehicleForm.valid) {
      console.log("valid.");

      this.vehicleService.updateVehicle(vehicleDataFromForm).subscribe({

        error: err => {
          this.errorMessage = err;
          console.log(this.errorMessage);
        },
        complete: () => {
          //doet hij enkel als er geen error is
          this.router.navigate(['/vehiclelist']);
        }
      });
    }

    else {
      console.log("not valid");
    }

  }

  onBack(): void {
    this.router.navigate(['/vehiclelist']);
  }
}

import { Component, OnInit } from '@angular/core';
import { IVehicle } from '../../domain/IVehicle';
import { FormBuilder, Validators } from '@angular/forms';
import { VehicleService } from '../vehicle.service';
import { Router } from '@angular/router';
import { EnumVehicleTypes } from '../../domain/enums/EnumVehicleTypes';
import { EnumFuelTypes } from '../../domain/enums/EnumFuelTypes';

@Component({
  selector: 'app-vehicleadd',
  templateUrl: './vehicleadd.component.html',
  styleUrls: ['./vehicleadd.component.css']
})
export class VehicleaddComponent implements OnInit {

  errorMessage = "";
  vehicle: IVehicle | undefined;
  vehicleForm: any;

  // Make a variable reference to our Enum and delete double values
  enumVehicleTypes = Object.keys(EnumVehicleTypes).filter(key => !isNaN(Number(EnumVehicleTypes[key])));
  enumFuelTypes = Object.keys(EnumFuelTypes).filter(key => !isNaN(Number(EnumFuelTypes[key])));

  constructor(private formBuilder: FormBuilder, private vehicleService: VehicleService,
    private router: Router) { }

  ngOnInit() {
    this.vehicleForm = this.formBuilder.group({

      ChassisNr: ['', [Validators.required]],
      FuelType: ['', [Validators.required]],
      VehicleType: ['', [Validators.required]],
      Mileage: ['', [Validators.required]]
    });
  }

  addVehicle(address: IVehicle): void {
    if (this.vehicleForm.valid) {
      console.log("valid.");

      const vehicleDataFromForm = this.vehicleForm.value;

      //convert to number, string was passed as value for option. "0" instead of 0
      vehicleDataFromForm.FuelType = Number(vehicleDataFromForm.FuelType);
      vehicleDataFromForm.VehicleType = Number(vehicleDataFromForm.VehicleType);

      this.vehicleService.addVehicle(vehicleDataFromForm).subscribe({
        //next: result => this.driver = result,
        error: err => this.errorMessage = err,
        complete: () => {
          //only executed when there is no error
          this.router.navigate(['/vehiclelist']);
        }
      });
    }
    else {
      console.log("not valid.");
    }
  }

}

import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../vehicle.service';
import { IVehicle } from '../../domain/IVehicle';

@Component({
  selector: 'app-vehiclelist',
  templateUrl: './vehiclelist.component.html',
  styleUrls: ['./vehiclelist.component.css', '../../shared/shared.css']
})
export class VehiclelistComponent implements OnInit {

  public vehicles: IVehicle[];
  errorMessage = '';

  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {

    this.vehicleService.getVehicles().subscribe({
      next: vehicles => {
        this.vehicles = vehicles;

      },
      error: err => this.errorMessage = err
    });
  }

  getFuelTypeViewValue(enumValue: number): string {

    return this.vehicleService.showEnumValueFuelType(enumValue);
  }

  getVehicleTypeViewValue(enumValue: number): string {

    return this.vehicleService.showEnumValueVehicleType(enumValue);
  }

}

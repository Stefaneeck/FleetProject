import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { VehicleService } from '../vehicle.service';
import { IVehicle } from '../../domain/IVehicle';
import { IMileageHistory } from '../../domain/IMileageHistory';
import { ILicensePlate } from '../../domain/ILicensePlate';

@Component({
  selector: 'app-vehicledetail',
  templateUrl: './vehicledetail.component.html',
  styleUrls: ['./vehicledetail.component.css', '../../shared/shared.css']
})
export class VehicledetailComponent implements OnInit {

  pageTitle: string = 'Vehicle detail';
  errorMessage = "";
  vehicle: IVehicle | undefined;
  vehicleMileageHistory: IMileageHistory[] | undefined;
  vehicleLicensePlates: ILicensePlate[] | undefined;

  constructor(private route: ActivatedRoute, private vehicleService: VehicleService, private router: Router) { }

  ngOnInit() {

    let id = +this.route.snapshot.paramMap.get('id');

    if (id) {
      this.getVehicle(id);
      this.getVehicleMileageHistory(id);
      this.getVehicleLicensePlates(id);
    }
    this.pageTitle += `: ${id}`;
  }


  getVehicle(id: number): void {
    this.vehicleService.getVehicle(id).subscribe({
      next: result => this.vehicle = result,
      error: err => this.errorMessage = err
    });
  }

  getVehicleMileageHistory(id: number): void {
    this.vehicleService.getVehicleMileageHistory(id).subscribe({
      next: result => this.vehicleMileageHistory = result,
      error: err => this.errorMessage = err
    });
  }

  getVehicleLicensePlates(id: number): void {
    this.vehicleService.getVehicleLicensePlates(id).subscribe({
      next: result => this.vehicleLicensePlates = result,
      error: err => this.errorMessage = err
    });
  }

  deleteVehicle(id: number): void {
    this.vehicleService.deleteVehicle(id).subscribe({

      error: err => {
        this.errorMessage = err;
        console.log("errormessage");
        console.log(this.errorMessage);
      },
      complete: () => {
        this.router.navigate(['/vehiclelist']);
      }
    });

  }

  getVehicleTypeViewValue(enumValue: number): string {

    return this.vehicleService.showEnumValueVehicleType(enumValue);
  }

  getFuelTypeViewValue(enumValue: number): string {

    return this.vehicleService.showEnumValueFuelType(enumValue);
  }

  onBack(): void {
    this.router.navigate(['/vehiclelist']);
  }

}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { VehicleService } from '../vehicle.service';
import { IVehicle } from '../../domain/IVehicle';

@Component({
  selector: 'app-vehicledetail',
  templateUrl: './vehicledetail.component.html',
  styleUrls: ['./vehicledetail.component.css', '../../shared/shared.css']
})
export class VehicledetailComponent implements OnInit {

  pageTitle: string = 'Vehicle detail';
  errorMessage = "";
  vehicle: IVehicle | undefined;

  constructor(private route: ActivatedRoute, private vehicleService: VehicleService, private router: Router) { }

  ngOnInit() {

    let id = +this.route.snapshot.paramMap.get('id');

    if (id) {
      this.getVehicle(id);
    }
    this.pageTitle += `: ${id}`;
  }

  getVehicle(id: number): void {
    this.vehicleService.getVehicle(id).subscribe({
      next: result => this.vehicle = result,
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

import { Component, OnInit } from '@angular/core';
import { IMaintenance } from '../../domain/IMaintenance';
import { MaintenanceService } from '../maintenance.service';

@Component({
  selector: 'app-maintenancelist',
  templateUrl: './maintenancelist.component.html',
  styleUrls: ['./maintenancelist.component.css']
})
export class MaintenancelistComponent implements OnInit {

  public maintenances: IMaintenance[];
  errorMessage = '';

  constructor(private maintenanceService: MaintenanceService) { }

  ngOnInit() {

    this.maintenanceService.getMaintenances().subscribe({
      next: maintenances => {
        this.maintenances = maintenances;

      },
      error: err => this.errorMessage = err
    });
  }

}

import { Component, OnInit } from '@angular/core';
import { IMaintenance } from '../../domain/IMaintenance';
import { ActivatedRoute, Router } from '@angular/router';
import { MaintenanceService } from '../maintenance.service';

@Component({
  selector: 'app-maintenancedetail',
  templateUrl: './maintenancedetail.component.html',
  styleUrls: ['./maintenancedetail.component.css']
})
export class MaintenancedetailComponent implements OnInit {

  pageTitle: string = 'Maintenance detail';
  errorMessage = "";
  maintenance: IMaintenance | undefined;

  constructor(private route: ActivatedRoute, private maintenanceService: MaintenanceService, private router: Router) { }

  ngOnInit() {

    let id = +this.route.snapshot.paramMap.get('id');

    if (id) {
      this.getMaintenance(id);
    }
    this.pageTitle += `: ${id}`;
  }

  getMaintenance(id: number): void {
    this.maintenanceService.getMaintenance(id).subscribe({

      next: result => this.maintenance = result,
      error: err => this.errorMessage = err
    });
  }

  deleteMaintenance(id: number): void {
    this.maintenanceService.deleteMaintenance(id).subscribe({

      error: err => {
        this.errorMessage = err;
        console.log("errormessage");
        console.log(this.errorMessage);
      },
      complete: () => {
        this.router.navigate(['/maintenancelist']);
      }
    });

  }

  onBack(): void {
    this.router.navigate(['/maintenancelist']);
  }
}

import { Component, OnInit } from '@angular/core';
import { IMaintenance } from '../../domain/IMaintenance';
import { FormBuilder, Validators } from '@angular/forms';
import { MaintenanceService } from '../maintenance.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-maintenanceadd',
  templateUrl: './maintenanceadd.component.html',
  styleUrls: ['./maintenanceadd.component.css']
})
export class MaintenanceaddComponent implements OnInit {

  errorMessage = "";
  maintenance: IMaintenance | undefined;
  maintenanceForm: any;

  constructor(private formBuilder: FormBuilder, private maintenanceService: MaintenanceService,
    private router: Router) { }

  ngOnInit() {

    this.maintenanceForm = this.formBuilder.group({

      MaintenanceDate: ['', [Validators.required]],
      Price: ['', [Validators.required]],
      DealerName: ['', [Validators.required]],
      InvoiceDocumentPath: ['', [Validators.required]],
      VehicleId: ['', [Validators.required]]
    });
  }

  addMaintenance(maintenance: IMaintenance): void {
    if (this.maintenanceForm.valid) {
      console.log("valid.");

      const maintenanceDataFromForm = this.maintenanceForm.value;

      this.maintenanceService.addMaintenance(maintenanceDataFromForm).subscribe({
        //next: result => this.driver = result,
        error: err => this.errorMessage = err,
        complete: () => {
          //only executed when there is no error
          this.router.navigate(['/maintenancelist']);
        }
      });
    }
    else {
      console.log("not valid.");
    }
  }

  onBack(): void {
    this.router.navigate(['/maintenancelist']);
  }

}

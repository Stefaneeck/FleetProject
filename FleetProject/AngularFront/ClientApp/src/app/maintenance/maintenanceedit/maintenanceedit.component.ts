import { Component, OnInit } from '@angular/core';
import { IMaintenance } from '../../domain/IMaintenance';
import { FormBuilder, Validators } from '@angular/forms';
import { MaintenanceService } from '../maintenance.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-maintenanceedit',
  templateUrl: './maintenanceedit.component.html',
  styleUrls: ['./maintenanceedit.component.css']
})
export class MaintenanceeditComponent implements OnInit {

  errorMessage = "";
  maintenance: IMaintenance | undefined;
  maintenanceForm: any;
  pageTitle: string = 'Edit maintenance';

  constructor(private formBuilder: FormBuilder, private maintenanceService: MaintenanceService,
    private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    let id = +this.route.snapshot.paramMap.get('id');

    if (id) {
      this.getMaintenance(id);
    }

    this.pageTitle += `: ${id}`;
  }

  getMaintenance(id: number): void {
    const promise = this.maintenanceService.getMaintenance(id).toPromise();

    promise.then((data: IMaintenance) => {

      this.maintenance = data;

      this.maintenanceForm = this.formBuilder.group({
        MaintenanceDate: ['', [Validators.required]],
        Price: ['', [Validators.required]],
        DealerName: ['', [Validators.required]],
        InvoiceDocumentPath: ['', [Validators.required]],
        VehicleId: ['', [Validators.required]]
      });

    }).catch((error) => {
      console.log("promise error");
      console.log(error);
    });
  }

  updateMaintenance(): void {
    let maintenanceDataFromForm = this.maintenanceForm.value;
    //add id manually
    maintenanceDataFromForm.id = this.maintenance.id;

    if (this.maintenanceForm.valid) {
      console.log("valid.");

      this.maintenanceService.updateMaintenance(maintenanceDataFromForm).subscribe({

        error: err => {
          this.errorMessage = err;
          console.log(this.errorMessage);
        },
        complete: () => {
          this.router.navigate(['/maintenancelist']);
        }
      });
    }

    else {
      console.log("not valid");
    }
  }

  onBack(): void {
    this.router.navigate(['/maintenancelist']);
  }

}

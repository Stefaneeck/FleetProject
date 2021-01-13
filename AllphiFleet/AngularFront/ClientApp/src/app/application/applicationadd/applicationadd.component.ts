import { Component, OnInit } from '@angular/core';
import { IApplication } from '../../domain/IApplication';
import { EnumApplicationStatuses } from '../../domain/enums/EnumApplicationStatuses';
import { EnumApplicationTypes } from '../../domain/enums/EnumApplicationTypes';
import { ApplicationService } from '../application.service';
import { FormBuilder, Validators, ValidationErrors } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-applicationadd',
  templateUrl: './applicationadd.component.html',
  styleUrls: ['./applicationadd.component.css']
})
export class ApplicationaddComponent implements OnInit {

  errorMessage = "";
  application: IApplication | undefined;
  applicationForm: any;

  // Make a variable reference to our Enum and delete double values
  enumAuthTypes = Object.keys(EnumApplicationStatuses).filter(key => !isNaN(Number(EnumApplicationStatuses[key])));
  enumDriverLicenseTypes = Object.keys(EnumApplicationTypes).filter(key => !isNaN(Number(EnumApplicationTypes[key])));

  constructor(private formBuilder: FormBuilder,
    private applicationService: ApplicationService,
    private router: Router) { }

  ngOnInit() {

    this.applicationForm = this.formBuilder.group({
      Id: ['', [Validators.required]],
      ApplicationDate: [null, [Validators.required]],
      ApplicationType: [null, [Validators.required]],
      PossibleDates: ['', [Validators.required]],
      ApplicationStatus: ['', [Validators.required]],
      CustomerId: [null, [Validators.required]],
      VehicleId: [null, [Validators.required]],
    });
  }

  addApplication(application: IApplication): void {
    if (this.applicationForm.valid) {
      console.log("valid.");

      const applicationDataFromForm = this.applicationForm.value;

      //convert to number, string was passed as value for option. "0" instead of 0
      applicationDataFromForm.ApplicationType = Number(applicationDataFromForm.ApplicationType);
      applicationDataFromForm.ApplicationValue = Number(applicationDataFromForm.ApplicationValue);

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
}

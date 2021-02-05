import { Component, OnInit } from '@angular/core';
import { IFuelcard } from '../../domain/IFuelcard';
import { FuelcardService } from '../fuelcard.service';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EnumAuthenticationTypes } from '../../domain/enums/EnumAuthenticationTypes';
import { formatDate } from '@angular/common';
import { UniqueFuelcardValidator } from '../unique.fuelcard.validator';

@Component({
  selector: 'app-fuelcardedit',
  templateUrl: './fuelcardedit.component.html',
  styleUrls: ['./fuelcardedit.component.css', '../../shared/shared.css']
})
export class FuelcardeditComponent implements OnInit {

  errorMessage = "";
  fuelcard: IFuelcard | undefined;
  fuelcardForm: any;
  pageTitle: string = 'Edit fuelcard';
  enumAuthTypes = Object.keys(EnumAuthenticationTypes).filter(key => !isNaN(Number(EnumAuthenticationTypes[key])));

  constructor(private formBuilder: FormBuilder, private fuelcardService: FuelcardService,
    private route: ActivatedRoute, private router: Router, private uniqueFuelcardValidator: UniqueFuelcardValidator) { }

  ngOnInit() {
    let id = +this.route.snapshot.paramMap.get('id');

    if (id) {
      this.getFuelcard(id);
    }

    this.pageTitle += `: ${id}`;
  }

  getFuelcard(id: number): void {
    const promise = this.fuelcardService.getFuelcard(id).toPromise();

    promise.then((data: IFuelcard) => {

      this.fuelcard = data;

      this.uniqueFuelcardValidator.initialValue = this.fuelcard.cardNumber;

      this.fuelcardForm = this.formBuilder.group({

        CardNumber: [this.fuelcard.cardNumber,
          {
            validators: [Validators.required],
            asyncValidators: [this.uniqueFuelcardValidator.validate.bind(this.uniqueFuelcardValidator)],
            updateOn: 'blur'
          }],
        Pincode: [this.fuelcard.pincode, [Validators.required]],
        AuthType: [this.fuelcard.authType, [Validators.required]],
        ValidUntilDate: [formatDate(this.fuelcard.validUntilDate, 'yyyy-MM-dd', 'en'), [Validators.required]],
        Options: [this.fuelcard.options, [Validators.required]],
        Active: [this.fuelcard.active, [Validators.required]]
      });

      const stringValue = this.fuelcard.authType.toString() + ": " + this.fuelcard.authType.toString();
      this.fuelcardForm.controls['AuthType'].setValue(stringValue, { onlySelf: true });

      console.log(stringValue);

    }).catch((error) => {
      console.log("promise error");
      console.log(error);
    });
  }

  updateFuelcard(): void {
    let fuelcardDataFromForm = this.fuelcardForm.value;
    //add id manually
    fuelcardDataFromForm.id = this.fuelcard.id;

    fuelcardDataFromForm.AuthType = Number(fuelcardDataFromForm.AuthType);

    //fix for when editing and didnt touch the checkbox, the value was NaN
    if (isNaN(fuelcardDataFromForm.AuthType)) {
      console.log("null");
      fuelcardDataFromForm.AuthType = this.fuelcard.authType;
    }

    if (this.fuelcardForm.valid) {
      console.log("valid.");

      this.fuelcardService.updateFuelcard(fuelcardDataFromForm).subscribe({

        //next: result => this.driver = result,
        error: err => {
          this.errorMessage = err;
          console.log(this.errorMessage);
        },
        complete: () => {
          this.router.navigate(['/fuelcardlist']);
        }
      });
    }

    else {
      console.log("not valid");
    }

  }

  onBack(): void {
    this.router.navigate(['/fuelcardlist']);
  }
}

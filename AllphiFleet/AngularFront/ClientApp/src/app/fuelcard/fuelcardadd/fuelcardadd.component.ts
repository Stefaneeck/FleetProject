import { Component, OnInit } from '@angular/core';
import { IFuelcard } from '../../domain/IFuelcard';
import { FormBuilder, Validators } from '@angular/forms';
import { AddressService } from '../../address/address.service';
import { Router } from '@angular/router';
import { FuelcardService } from '../fuelcard.service';
import { EnumAuthenticationTypes } from '../../domain/enums/EnumAuthenticationTypes';
import { UniqueFuelcardValidator } from '../unique.fuelcard.validator';

@Component({
  selector: 'app-fuelcardadd',
  templateUrl: './fuelcardadd.component.html',
  styleUrls: ['./fuelcardadd.component.css', '../../shared/shared.css']
})
export class FuelcardaddComponent implements OnInit {

  errorMessage = "";
  fuelcard: IFuelcard | undefined;
  //datatype nog veranderen naar concreter type
  fuelcardForm: any;
  enumAuthTypes = Object.keys(EnumAuthenticationTypes).filter(key => !isNaN(Number(EnumAuthenticationTypes[key])));

  constructor(private formBuilder: FormBuilder, private fuelcardService: FuelcardService,
    private router: Router, private uniqueFuelcardValidator: UniqueFuelcardValidator) { }

  ngOnInit() {

    this.fuelcardForm = this.formBuilder.group({

      CardNumber: ['', {
        validators: [Validators.required],
        asyncValidators: [this.uniqueFuelcardValidator.validate.bind(this.uniqueFuelcardValidator)],
        updateOn: 'blur'
      }],
      Pincode: ['', [Validators.required]],
      AuthType: ['', [Validators.required]],
      ValidUntilDate: ['', [Validators.required]],
      Options: ['', [Validators.required]],
      //Not visible in html.Not being inputted by user, just default to true
      Active: [true, [Validators.required]]
    });
  }

  addFuelcard(): void {
    if (this.fuelcardForm.valid) {
      console.log("valid.");

      const fuelcardDataFromForm = this.fuelcardForm.value;

      fuelcardDataFromForm.AuthType = Number(fuelcardDataFromForm.AuthType);

      this.fuelcardService.addFuelcard(fuelcardDataFromForm).subscribe({
        //next: result => this.driver = result,
        error: err => this.errorMessage = err,
        complete: () => {
          //doet hij enkel als er geen error is
          this.router.navigate(['/fuelcardlist']);
        }
      });
    }
    else {
      console.log("not valid.");
    }
  }

  onBack(): void {
    this.router.navigate(['/fuelcardlist']);
  }
}

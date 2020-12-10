import { Component, OnInit } from '@angular/core';
import { IAddress } from '../../domain/IAddress';
import { Router } from '@angular/router';
import { AddressService } from '../address.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-addressadd',
  templateUrl: './addressadd.component.html',
  styleUrls: ['./addressadd.component.css']
})
export class AddressaddComponent implements OnInit {

  errorMessage = "";
  address: IAddress | undefined;
  //datatype nog veranderen naar concreter type
  addressForm: any;

  constructor(private formBuilder: FormBuilder, private addressService: AddressService,
    private router: Router) { }

  ngOnInit() {

    this.addressForm = this.formBuilder.group({

      Straat: ['', [Validators.required]],
      Nummer: ['', [Validators.required]],
      Postcode: ['', [Validators.required]],
      Stad: ['', [Validators.required]]
    });
  }

  addAddress(address: IAddress): void {
    if (this.addressForm.valid) {
      console.log("valid.");

      const addressDataFromForm = this.addressForm.value;

      this.addressService.addAddress(addressDataFromForm).subscribe({
        //next: result => this.driver = result,
        error: err => this.errorMessage = err,
        complete: () => {
          //doet hij enkel als er geen error is
          this.router.navigate(['/addresslist']);
        }
      });
    }
    else {
      console.log("not valid.");
    }
  }
}

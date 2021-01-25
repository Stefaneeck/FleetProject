import { Component, OnInit } from '@angular/core';
import { IAddress } from '../../domain/IAddress';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AddressService } from '../address.service';

@Component({
  selector: 'app-addressedit',
  templateUrl: './addressedit.component.html',
  styleUrls: ['./addressedit.component.css']
})
export class AddresseditComponent implements OnInit {

  errorMessage = "";
  address: IAddress | undefined;
  addressForm: any;
  pageTitle: string = 'Edit address';

  constructor(private formBuilder: FormBuilder, private addressService: AddressService,
    private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    let id = +this.route.snapshot.paramMap.get('id');

    if (id) {
      this.getAddress(id);
    }

    this.pageTitle += `: ${id}`;
  }
  
  getAddress(id: number): void {
    const promise = this.addressService.getAddress(id).toPromise();

    promise.then((data: IAddress) => {

      this.address = data;

      this.addressForm = this.formBuilder.group({
        Street: [this.address.street, [Validators.required]],
        Number: [this.address.number, [Validators.required]],
        Zipcode: [this.address.zipcode, [Validators.required]],
        City: [this.address.city, [Validators.required]],

      });

    }).catch((error) => {
      console.log("promise error");
    });
  }

  updateAddress(address: IAddress): void {
    let addressDataFromForm = this.addressForm.value;
    //add id manually
    addressDataFromForm.id = this.address.id;

    if (this.addressForm.valid) {
      console.log("valid.");

      this.addressService.updateAddress(addressDataFromForm).subscribe({
        //info https://rxjs-dev.firebaseapp.com/guide/observer
        //Observers are just objects with three callbacks, one for each type of notification that an Observable may deliver. (next, error or complete)

        //next: result => this.driver = result,
        error: err => {
          this.errorMessage = err;
          console.log(this.errorMessage);
        },
        complete: () => {
          //doet hij enkel als er geen error is
          this.router.navigate(['/addresslist']);
        }
      });
    }

    else {
      console.log("not valid");
    }
  }

  onBack(): void {
    this.router.navigate(['/addresslist']);
  }
}

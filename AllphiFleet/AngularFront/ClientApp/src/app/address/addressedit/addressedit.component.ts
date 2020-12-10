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

      //we spreken hier het json object eigenlijk aan, we moeten zien dat onze domeinklasse de data ervan matcht. als we this.driver.Naam ipv this.driver.naam zouden gebruiken, zou het niet werken
      //omdat het json object met kleine letters uit de api komt. we moeten dus hier de syntax van onze domeinklasse aanpassen aan hoe het in het json object zit, er wordt niets intern automatisch gemapt.

      this.addressForm = this.formBuilder.group({
        Straat: [this.address.straat, [Validators.required]],
        Nummer: [this.address.nummer, [Validators.required]],
        Postcode: [this.address.postcode, [Validators.required]],
        Stad: [this.address.stad, [Validators.required]],

      });

    }).catch((error) => {
      console.log("promise error");
    });
  }

  updateAddress(address: IAddress): void {
    let addressDataFromForm = this.addressForm.value;
    //id manueel toevoegen
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
}

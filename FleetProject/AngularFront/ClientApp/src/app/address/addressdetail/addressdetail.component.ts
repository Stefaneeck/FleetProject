import { Component, OnInit } from '@angular/core';
import { IAddress } from '../../domain/IAddress';
import { ActivatedRoute, Router } from '@angular/router';
import { AddressService } from '../address.service';

@Component({
  selector: 'app-addressdetail',
  templateUrl: './addressdetail.component.html',
  styleUrls: ['./addressdetail.component.css', '../../shared/shared.css']
})
export class AddressdetailComponent implements OnInit {

  pageTitle: string = 'Address detail';
  errorMessage = "";
  address: IAddress | undefined;

  constructor(private route: ActivatedRoute, private addressService: AddressService, private router: Router) { }

  ngOnInit() {

    let id = +this.route.snapshot.paramMap.get('id');

    //if id is truthy
    if (id) {
      this.getAddress(id);
    }
    this.pageTitle += `: ${id}`;
  }

  getAddress(id: number): void {
    this.addressService.getAddress(id).subscribe({
      //save response data from request in local variable
      next: result => this.address = result,
      error: err => this.errorMessage = err
    });
  }

  deleteAddress(id: number): void {
    this.addressService.deleteAddress(id).subscribe({

      error: err => {
        this.errorMessage = err;
        console.log("errormessage");
        console.log(this.errorMessage);
      },
      complete: () => {
        //only exectures if no error has occured
        this.router.navigate(['/addresslist']);
      }
    });

  }

  onBack(): void {
    this.router.navigate(['/addresslist']);
  }
}

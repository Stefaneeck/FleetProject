import { Component, OnInit } from '@angular/core';
import { IAddress } from '../../domain/IAddress';
import { AddressService } from '../address.service';

@Component({
  selector: 'app-addresslist',
  templateUrl: './addresslist.component.html',
  styleUrls: ['./addresslist.component.css', '../../shared/shared.css']
})
export class AddresslistComponent implements OnInit {

  public addresses: IAddress[];
  errorMessage = '';


  constructor(private addressService: AddressService) { }

  ngOnInit() : void {

    this.addressService.getAddresses().subscribe({
      next: addresses => {
        this.addresses = addresses;
        //this.filteredProducts = this.products;
      },
      error: err => this.errorMessage = err
    });
  }

}

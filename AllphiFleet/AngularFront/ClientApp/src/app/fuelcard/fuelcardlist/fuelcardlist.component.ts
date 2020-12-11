import { Component, OnInit } from '@angular/core';
import { IFuelcard } from '../../domain/IFuelcard';
import { FuelcardService } from '../fuelcard.service';

@Component({
  selector: 'app-fuelcardlist',
  templateUrl: './fuelcardlist.component.html',
  styleUrls: ['./fuelcardlist.component.css']
})
export class FuelcardlistComponent implements OnInit {

  public fuelcards: IFuelcard[];
  errorMessage = '';

  constructor(private fuelcardService: FuelcardService) { }

  ngOnInit() {

    this.fuelcardService.getFuelcards().subscribe({
      next: fuelcards => {
        this.fuelcards = fuelcards;
        //this.filteredProducts = this.products;
      },
      error: err => this.errorMessage = err
    });
  }
}


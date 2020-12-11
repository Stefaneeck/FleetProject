import { Component, OnInit } from '@angular/core';
import { IFuelcard } from '../../domain/IFuelcard';
import { FuelcardService } from '../fuelcard.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-fuelcarddetail',
  templateUrl: './fuelcarddetail.component.html',
  styleUrls: ['./fuelcarddetail.component.css']
})
export class FuelcarddetailComponent implements OnInit {

  pageTitle: string = 'Fuelcard detail';
  errorMessage = "";
  address: IFuelcard | undefined;

  constructor(private route: ActivatedRoute, private fuelcardService: FuelcardService, private router: Router) { }

  ngOnInit() {
  }

}

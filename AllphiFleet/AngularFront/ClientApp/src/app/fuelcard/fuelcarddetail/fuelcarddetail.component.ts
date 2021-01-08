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
  fuelcard: IFuelcard | undefined;

  constructor(private route: ActivatedRoute, private fuelcardService: FuelcardService, private router: Router) { }

  ngOnInit() {

    let id = +this.route.snapshot.paramMap.get('id');

    if (id) {
      this.getFuelcard(id);
    }
    this.pageTitle += `: ${id}`;
  }

  getFuelcard(id: number): void {
    this.fuelcardService.getFuelcard(id).subscribe({
      //opgehaalde waarde in lokale fuelcard variabele opslaan
      next: result => this.fuelcard = result,
      error: err => this.errorMessage = err
    });
  }

  deleteFuelcard(id: number): void {
    this.fuelcardService.deleteFuelcard(id).subscribe({

      error: err => {
        this.errorMessage = err;
        console.log("errormessage");
        console.log(this.errorMessage);
      },
      complete: () => {
        //doet hij enkel als er geen error is, hij doet altijd maar 1 van de 3 (next, error of complete).
        this.router.navigate(['/fuelcardlist']);
      }
    });

  }

  onBack(): void {
    this.router.navigate(['/fuelcardlist']);
  }

  getAuthTypeViewValue(enumValue: number): string {

    return this.fuelcardService.showEnumValueAuthType(enumValue);
  }

}

import { Component, OnInit } from '@angular/core';
import { DriverService } from '../driver/driver.service';

@Component({
  selector: 'app-privacy',
  templateUrl: './privacy.component.html',
  styleUrls: ['./privacy.component.css']
})
export class PrivacyComponent implements OnInit {
  public claims: [] = [];

  constructor(private driverService: DriverService) { }

  ngOnInit() {
    this.getClaims();
  }

  public getClaims = () => {
    this.driverService.getClaims()
      .subscribe(res => {
        this.claims = res as [];
      })
  }

}

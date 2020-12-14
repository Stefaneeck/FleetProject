import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { DriverlistComponent } from './driver/driverlist/driverlist.component';
import { DriverdetailComponent } from './driver/driverdetail/driverdetail.component';
import { DriveraddComponent } from './driver/driveradd/driveradd.component';
import { DrivereditComponent } from './driver/driveredit/driveredit.component';
import { AddresslistComponent } from './address/addresslist/addresslist.component';
import { AddressdetailComponent } from './address/addressdetail/addressdetail.component';
import { AddresseditComponent } from './address/addressedit/addressedit.component';
import { AddressaddComponent } from './address/addressadd/addressadd.component';
import { FuelcardlistComponent } from './fuelcard/fuelcardlist/fuelcardlist.component';
import { FuelcarddetailComponent } from './fuelcard/fuelcarddetail/fuelcarddetail.component';
import { FuelcardaddComponent } from './fuelcard/fuelcardadd/fuelcardadd.component';
import { FuelcardeditComponent } from './fuelcard/fuelcardedit/fuelcardedit.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    DriverlistComponent,
    DriverdetailComponent,
    DriveraddComponent,
    DrivereditComponent,
    AddresslistComponent,
    AddressdetailComponent,
    AddresseditComponent,
    AddressaddComponent,
    FuelcardlistComponent,
    FuelcarddetailComponent,
    FuelcardaddComponent,
    FuelcardeditComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'driverlist', component: DriverlistComponent },
      { path: 'driver/:id', component: DriverdetailComponent },
      { path: 'driveradd', component: DriveraddComponent },
      { path: 'driveredit/:id', component: DrivereditComponent },
      { path: 'addresslist', component: AddresslistComponent },
      { path: 'address/:id', component: AddressdetailComponent },
      { path: 'addressedit/:id', component: AddresseditComponent },
      { path: 'addressadd', component: AddressaddComponent },
      { path: 'fuelcardlist', component: FuelcardlistComponent },
      { path: 'fuelcard/:id', component: FuelcarddetailComponent },
      { path: 'fuelcardadd', component: FuelcardaddComponent },
      { path: 'fuelcardedit/:id', component: FuelcardeditComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

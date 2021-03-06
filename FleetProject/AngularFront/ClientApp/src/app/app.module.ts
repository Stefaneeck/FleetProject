import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { OAuthModule } from 'angular-oauth2-oidc';
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
import { SigninRedirectCallbackComponent } from './signin-redirect-callback/signin-redirect-callback.component';
import { SignoutRedirectCallbackComponent } from './signout-redirect-callback/signout-redirect-callback.component';
import { AuthInterceptorService } from './shared/services/auth-interceptor.service';
import { PrivacyComponent } from './privacy/privacy.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { AuthGuardService } from './shared/guards/auth-guard.service';
import { ApplicationlistComponent } from './application/applicationlist/applicationlist.component';
import { ApplicationaddComponent } from './application/applicationadd/applicationadd.component';
import { ApplicationdetailComponent } from './application/applicationdetail/applicationdetail.component';
import { ApplicationeditComponent } from './application/applicationedit/applicationedit.component';
import { VehiclelistComponent } from './vehicle/vehiclelist/vehiclelist.component';
import { VehicleaddComponent } from './vehicle/vehicleadd/vehicleadd.component';
import { VehicleeditComponent } from './vehicle/vehicleedit/vehicleedit.component';
import { VehicledetailComponent } from './vehicle/vehicledetail/vehicledetail.component';
import { MaintenancelistComponent } from './maintenance/maintenancelist/maintenancelist.component';
import { MaintenanceaddComponent } from './maintenance/maintenanceadd/maintenanceadd.component';
import { MaintenanceeditComponent } from './maintenance/maintenanceedit/maintenanceedit.component';
import { MaintenancedetailComponent } from './maintenance/maintenancedetail/maintenancedetail.component';

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
    FuelcardeditComponent,
    SigninRedirectCallbackComponent,
    SignoutRedirectCallbackComponent,
    PrivacyComponent,
    UnauthorizedComponent,
    ApplicationlistComponent,
    ApplicationaddComponent,
    ApplicationdetailComponent,
    ApplicationeditComponent,
    VehiclelistComponent,
    VehicleaddComponent,
    VehicleeditComponent,
    VehicledetailComponent,
    MaintenancelistComponent,
    MaintenanceaddComponent,
    MaintenanceeditComponent,
    MaintenancedetailComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: DriverlistComponent, pathMatch: 'full' },
      //canActivate from route guard, user must be logged in or client side redirect
      { path: 'driverlist', component: DriverlistComponent, canActivate: [AuthGuardService] },
      { path: 'driver/:id', component: DriverdetailComponent, canActivate: [AuthGuardService] },
      { path: 'driveradd', component: DriveraddComponent, canActivate: [AuthGuardService] },
      { path: 'driveredit/:id', component: DrivereditComponent, canActivate: [AuthGuardService] },
      { path: 'addresslist', component: AddresslistComponent },
      { path: 'address/:id', component: AddressdetailComponent, canActivate: [AuthGuardService] },
      { path: 'addressedit/:id', component: AddresseditComponent, canActivate: [AuthGuardService] },
      { path: 'addressadd', component: AddressaddComponent, canActivate: [AuthGuardService] },
      { path: 'fuelcardlist', component: FuelcardlistComponent, canActivate: [AuthGuardService] },
      { path: 'fuelcard/:id', component: FuelcarddetailComponent, canActivate: [AuthGuardService] },
      { path: 'fuelcardadd', component: FuelcardaddComponent, canActivate: [AuthGuardService] },
      { path: 'fuelcardedit/:id', component: FuelcardeditComponent, canActivate: [AuthGuardService] },
      //The value of the path property must match the value we assigned to the redirect_uri property of the UserManager settings in the AuthService class.
      { path: 'signin-callback', component: SigninRedirectCallbackComponent },
      { path: 'signout-callback', component: SignoutRedirectCallbackComponent },
      //routeguard, user must be logged in and role admin
      //{ path: 'privacy', component: PrivacyComponent, canActivate: [AuthGuardService], data: { roles: ['Admin'] } },
      { path: 'privacy', component: PrivacyComponent },
      { path: 'unauthorized', component: UnauthorizedComponent },
      { path: 'applicationlist', component: ApplicationlistComponent, canActivate: [AuthGuardService] },
      { path: 'application/:id', component: ApplicationdetailComponent, canActivate: [AuthGuardService] },
      { path: 'applicationadd', component: ApplicationaddComponent, canActivate: [AuthGuardService] },
      { path: 'applicationedit/:id', component: ApplicationeditComponent, canActivate: [AuthGuardService] },
      { path: 'vehiclelist', component: VehiclelistComponent, canActivate: [AuthGuardService] },
      { path: 'vehicle/:id', component: VehicledetailComponent, canActivate: [AuthGuardService] },
      { path: 'vehicleadd', component: VehicleaddComponent, canActivate: [AuthGuardService] },
      { path: 'vehicleedit/:id', component: VehicleeditComponent, canActivate: [AuthGuardService] },
      { path: 'maintenancelist', component: MaintenancelistComponent, canActivate: [AuthGuardService] },
      { path: 'maintenance/:id', component: MaintenancedetailComponent, canActivate: [AuthGuardService] },
      { path: 'maintenanceadd', component: MaintenanceaddComponent, canActivate: [AuthGuardService] },
      { path: 'maintenanceedit/:id', component: MaintenanceeditComponent, canActivate: [AuthGuardService] },
    ]),
    OAuthModule.forRoot()
  ],
  providers: [
    /*
     * Providers are usually singleton (one instance) objects, that other objects have access to through dependency injection (DI).
      If you plan to use an object multiple times, for example Http service in different components, you can ask for same instance of that service.
     */
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

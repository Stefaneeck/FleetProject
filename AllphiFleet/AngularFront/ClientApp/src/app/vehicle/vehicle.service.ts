import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { IVehicle} from '../domain/IVehicle';
import { EnumVehicleTypes } from '../domain/enums/EnumVehicleTypes';
import { EnumFuelTypes } from '../domain/enums/EnumFuelTypes';
import { IMileageHistory } from '../domain/IMileageHistory';
import { ILicensePlate } from '../domain/ILicensePlate';


@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  private vehicleReadUrl = 'https://localhost:44334/api/vehicle';
  private vehicleWriteUrl = 'https://localhost:44358/writeapi/vehicle'

  constructor(private http: HttpClient) { }


  getVehicles(): Observable<IVehicle[]> {
    return this.http.get<IVehicle[]>(this.vehicleReadUrl)
      .pipe(
        tap(data => console.log('getVehicles: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getVehicle(id: number): Observable<IVehicle | undefined> {
    return this.http.get<IVehicle>(this.vehicleReadUrl + '/' + id)
      .pipe(
        tap(data => console.log('getVehicle: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );

  }

  getVehicleMileageHistory(vehicleId: number): Observable<IMileageHistory[] | undefined> {
    return this.http.get<IMileageHistory[]>(this.vehicleReadUrl + '/getmileagehistory/' + vehicleId)
      .pipe(
        tap(data => console.log('getVehicleMileageHistory: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );

  }

  getVehicleLicensePlates(id: number): Observable<ILicensePlate[] | undefined> {
    return this.http.get<ILicensePlate[]>(this.vehicleReadUrl + '/getvehiclelicenseplates/' + id)
      .pipe(
        tap(data => console.log('getVehicleLicensePlates: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );

  }

  addVehicle(vehicleData: IVehicle): Observable<IVehicle> {
    const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<IVehicle>(this.vehicleWriteUrl, vehicleData, httpHeaders)
      .pipe(
        tap(data => console.log('addVehicle: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  updateVehicle(vehicleData: IVehicle): Observable<IVehicle> {
    const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<IVehicle>(this.vehicleWriteUrl + '/update' + '/' + vehicleData.id, vehicleData, httpHeaders)
      .pipe(
        tap(data => console.log('updateVehicle: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  deleteVehicle(id: number): Observable<IVehicle> {
    return this.http.delete<IVehicle>(this.vehicleWriteUrl + '/delete' + '/' + id)
      .pipe(
        tap(data => console.log('All: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  showEnumValueVehicleType(value: number): string {

    return EnumVehicleTypes[value];
  }

  showEnumValueFuelType(value: number): string {

    return EnumFuelTypes[value];
  }

  private handleError(err: HttpErrorResponse): Observable<never> {
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}

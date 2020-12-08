import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';

import { IDriver } from './IDriver';


@Injectable({
  providedIn: 'root'
})
export class DriverService {
  // If using Stackblitz, replace the url with this line
  // because Stackblitz can't find the api folder.
  // private productUrl = 'assets/products/products.json';
  private driverReadUrl = 'https://localhost:44334/api/chauffeur';
  private driverWriteUrl ='https://localhost:44358/writeapi/chauffeur'

  constructor(private http: HttpClient) { }

  getDrivers(): Observable<IDriver[]> {
    return this.http.get<IDriver[]>(this.driverReadUrl)
      .pipe(
        tap(data => console.log('All: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  //undefined pipe uitzoeken
  getDriver(id: number): Observable<IDriver | undefined> {
    //creatie van url voor chauffeur op te halen nog opschonen
    return this.http.get<IDriver>(this.driverReadUrl + '/' + id)
      .pipe(
        tap(data => console.log('All: ' + JSON.stringify(data))),
        catchError(this.handleError)
    );

  }

  postDriver(driverData: IDriver): Observable<IDriver> {
    const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<IDriver>(this.driverWriteUrl, driverData, httpHeaders)
      .pipe(
        tap(data => console.log('All: ' + JSON.stringify(data))),
        catchError(this.handleError)
    );
  }

  private handleError(err: HttpErrorResponse): Observable<never> {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}

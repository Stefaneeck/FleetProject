import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError, from } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { IDriver } from '../domain/IDriver';
import { EnumDriverLicenseTypes } from '../domain/enums/EnumDriverLicenseTypes';
import { AuthService } from '../shared/services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class DriverService {
  private driverReadUrl = 'https://localhost:44334/api/driver';
  private driverWriteUrl = 'https://localhost:44358/writeapi/driver';

  constructor(private http: HttpClient, private authService : AuthService) { }

  //You have to subscribe to the call if you want it to execute
  //we subscriben hier niet, maar wel waar we de methode aanroepen

  getDrivers(): Observable<IDriver[]> {
    return this.http.get<IDriver[]>(this.driverReadUrl)
      .pipe(
        tap(data => console.log('getDrivers: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  /* Example: manually add token to request
   * 
   * We need access to the getAccessToken function and for that, we have to inject the _authService object.
   * Then, inside the getData function, we call the getAccessToken function and attach a callback with the then function to resolve the promise.
   * Inside the callback, we create a headers property by instantiating the HttpHeaders class
   * and calling the set function where we pass the name of the header and the token itself with the Bearer prefix.
   *
   * After that, we have an http get request but this time with the headers object included and converted to promise.
   * If we leave it like this, we are going to return a Promise<object> from this function, and for our current setup,
   * the getData function should return the Observable<object>. So, to do that, we have to wrap this body inside the from() function from rxjs.
   *
   * note:
   * Right now, we only have one HTTP call to the Web API. But in a real-world application, we would have more than one repository file and for sure more HTTP calls.
   * With the solution, as we have it now, we have to make the same changes on each HTTP function all over the project and duplicate the same code.
   * To improve this solution, we are going to create a centralized place to inject the access token in the request and use that logic in our HTTP calls without the code repetition.
   
  */

  getDriver(id: number): Observable<IDriver | undefined> {
    return this.http.get<IDriver>(this.driverReadUrl + '/' + id)
      .pipe(
        tap(data => console.log('getDriver: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );

  }

  getDriverBySocSecNr(socSecNr: string): Observable<number | undefined> {
    return this.http.get<number>(this.driverReadUrl + '/GetbySocSecNr/' + socSecNr)
      .pipe(
        tap(data => console.log('getDriverBySocSecNr: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );

  }

  addDriver(driverData: IDriver): Observable<IDriver> {
    const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<IDriver>(this.driverWriteUrl, driverData, httpHeaders)
      .pipe(
        tap(data => console.log('addDriver: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  updateDriver(driverData: IDriver): Observable<IDriver> {
    const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<IDriver>(this.driverWriteUrl + '/update' + '/' + driverData.id, driverData, httpHeaders)
      .pipe(
        tap(data => console.log('updateDriver: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  deleteDriver(id: number): Observable<IDriver> {
    return this.http.delete<IDriver>(this.driverWriteUrl + '/delete' + '/' + id)
      .pipe(
        tap(data => console.log('All: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  showEnumValueDriverLicenseType(value: number): string {
 
    return EnumDriverLicenseTypes[value];
  }

  //todo: move to auth service? should be placed in auth api as well on c# side and not in driver api
  getClaims(): Observable<any> {
    return this.http.get(this.driverReadUrl + '/claims')
      .pipe(
        tap(data => console.log('getClaims: ' + JSON.stringify(data))),
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

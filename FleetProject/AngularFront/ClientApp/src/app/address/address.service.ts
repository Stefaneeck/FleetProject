import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { IAddress } from '../domain/IAddress';


@Injectable({
  providedIn: 'root'
})
export class AddressService {
  private addressReadUrl = 'https://localhost:44334/api/address';
  private addressWriteUrl = 'https://localhost:44358/writeapi/address'

  constructor(private http: HttpClient) { }

  getAddresses(): Observable<IAddress[]> {
    /*
     *The pipe() function takes as its arguments the functions you want to combine,
     and returns a new function that, when executed, runs the composed functions in sequence.
     tap() - RxJS tap operator will look at the Observable value and do something with that value.
     In other words, after a successful API request, the tap() operator will do any function you want it to perform with the response.
     */
    return this.http.get<IAddress[]>(this.addressReadUrl)
      .pipe(
        tap(data => console.log('getAddresses: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getAddress(id: number): Observable<IAddress | undefined> {
    return this.http.get<IAddress>(this.addressReadUrl + '/' + id)
      .pipe(
        tap(data => console.log('getAddress: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );

  }

  addAddress(addressData: IAddress): Observable<IAddress> {
    const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<IAddress>(this.addressWriteUrl, addressData, httpHeaders)
      .pipe(
        tap(data => console.log('addAddress: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  updateAddress(addressData: IAddress): Observable<IAddress> {
    const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<IAddress>(this.addressWriteUrl + '/update' + '/' + addressData.id, addressData, httpHeaders)
      .pipe(
        tap(data => console.log('updateAddress: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  deleteAddress(id: number): Observable<IAddress> {
    return this.http.delete<IAddress>(this.addressWriteUrl + '/delete' + '/' + id)
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

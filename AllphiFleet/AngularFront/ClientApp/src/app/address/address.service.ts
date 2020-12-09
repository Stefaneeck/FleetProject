import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { IAddress } from '../domain/IAddress';


@Injectable({
  providedIn: 'root'
})
export class AddressService {
  // If using Stackblitz, replace the url with this line
  // because Stackblitz can't find the api folder.
  // private productUrl = 'assets/products/products.json';
  private addressReadUrl = 'https://localhost:44334/api/adres';
  private addressWriteUrl = 'https://localhost:44358/writeapi/adres'

  constructor(private http: HttpClient) { }

  //You have to subscribe to the call if you want it to execute
  //we subscriben hier niet, maar wel waar we de methode aanroepen
  getAddresses(): Observable<IAddress[]> {
    return this.http.get<IAddress[]>(this.addressReadUrl)
      .pipe(
        tap(data => console.log('getAddresses: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getAddress(id: number): Observable<IAddress | undefined> {
    //creatie van url voor chauffeur op te halen nog opschonen
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

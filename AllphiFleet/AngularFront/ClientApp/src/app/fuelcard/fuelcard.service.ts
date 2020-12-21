import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { IFuelcard} from '../domain/IFuelcard';


@Injectable({
  providedIn: 'root'
})
export class FuelcardService {
  private fuelcardReadUrl = 'https://localhost:44334/api/tankkaart';
  private fuelcardWriteUrl = 'https://localhost:44358/writeapi/tankkaart'

  constructor(private http: HttpClient) { }


  getFuelcards(): Observable<IFuelcard[]> {
    return this.http.get<IFuelcard[]>(this.fuelcardReadUrl)
      .pipe(
        tap(data => console.log('getFuelCards: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getFuelcard(id: number): Observable<IFuelcard | undefined> {
    //creatie van url voor chauffeur op te halen nog opschonen
    return this.http.get<IFuelcard>(this.fuelcardReadUrl + '/' + id)
      .pipe(
        tap(data => console.log('getFuelcard: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );

  }

  addFuelcard(fuelcardData: IFuelcard): Observable<IFuelcard> {
    const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<IFuelcard>(this.fuelcardWriteUrl, fuelcardData, httpHeaders)
      .pipe(
        tap(data => console.log('addFuelcard: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  updateFuelcard(fuelcardData: IFuelcard): Observable<IFuelcard> {
    const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<IFuelcard>(this.fuelcardWriteUrl + '/update' + '/' + fuelcardData.id, fuelcardData, httpHeaders)
      .pipe(
        tap(data => console.log('updateFuelcard: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  deleteFuelcard(id: number): Observable<IFuelcard> {
    return this.http.delete<IFuelcard>(this.fuelcardWriteUrl + '/delete' + '/' + id)
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

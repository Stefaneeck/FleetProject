import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { LoginDTO } from '../domain/DTO/LoginDTO';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  // If using Stackblitz, replace the url with this line
  // because Stackblitz can't find the api folder.
  // private productUrl = 'assets/products/products.json';
  private apiLoginUrl = 'https://localhost:44334/api/auth/SignIn';

  constructor(private http: HttpClient) { }


  validateLoginAndGetToken(loginDTO: LoginDTO): Observable<string | undefined> {
    //as 'text' moest want anders error
    let httpOptionsPlain = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      }),
      responseType: 'text' as 'text'
    };
    return this.http.post(this.apiLoginUrl, loginDTO, httpOptionsPlain)
      //pipe laat ons meerdere functies combineren
      //The pipe() function takes as its arguments the functions you want to combine,
      //and returns a new function that, when executed, runs the composed functions in sequence.

     //tap() - RxJS tap operator will look at the Observable value and do something with that value.
     //In other words, after a successful API request, the tap() operator will do any function you want it to perform with the response.In the example, it will just log that string.
      .pipe(
        tap(data => {
          console.log('validateLogin: ' + JSON.stringify(data));
         
        }),
        catchError(this.handleError)
      );

  }
  /*

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

*/

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

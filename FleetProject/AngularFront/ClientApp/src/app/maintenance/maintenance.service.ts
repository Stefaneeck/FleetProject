import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError, from } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { AuthService } from '../shared/services/auth.service';
import { IMaintenance } from '../domain/IMaintenance';

@Injectable({
  providedIn: 'root'
})
export class MaintenanceService {
  private maintenanceReadUrl = 'https://localhost:44334/api/maintenance';
  private maintenanceWriteUrl = 'https://localhost:44358/writeapi/maintenance';

  constructor(private http: HttpClient, private authService: AuthService) { }

  //You have to subscribe to the call if you want it to execute
  //we subscriben hier niet, maar wel waar we de methode aanroepen

  getMaintenances(): Observable<IMaintenance[]> {
    return this.http.get<IMaintenance[]>(this.maintenanceReadUrl)
      .pipe(
        tap(data => console.log('getMaintenances: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getMaintenance(id: number): Observable<IMaintenance | undefined> {
    return this.http.get<IMaintenance>(this.maintenanceReadUrl + '/' + id)
      .pipe(
        tap(data => console.log('getMaintenance: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );

  }

  addMaintenance(maintenanceData: IMaintenance): Observable<IMaintenance> {
    const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<IMaintenance>(this.maintenanceWriteUrl, maintenanceData, httpHeaders)
      .pipe(
        tap(data => console.log('addMaintenance: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  updateMaintenance(maintenanceData: IMaintenance): Observable<IMaintenance> {
    const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<IMaintenance>(this.maintenanceWriteUrl + '/update' + '/' + maintenanceData.id, maintenanceData, httpHeaders)
      .pipe(
        tap(data => console.log('updateMaintenance: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  deleteMaintenance(id: number): Observable<IMaintenance> {
    return this.http.delete<IMaintenance>(this.maintenanceWriteUrl + '/delete' + '/' + id)
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

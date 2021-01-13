import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError, from } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { EnumApplicationTypes } from '../domain/enums/EnumApplicationTypes';
import { EnumApplicationStatuses } from '../domain/enums/EnumApplicationStatuses';
import { AuthService } from '../shared/services/auth.service';
import { IApplication } from '../domain/IApplication';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {

  private applicationReadUrl = 'https://localhost:44334/api/application';
  private applicationWriteUrl = 'https://localhost:44358/writeapi/application';

  constructor(private http: HttpClient, private authService: AuthService) { }

  getApplications(): Observable<IApplication[]> {
    return this.http.get<IApplication[]>(this.applicationReadUrl)
      .pipe(
        tap(data => console.log('getApplications: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getApplication(id: number): Observable<IApplication | undefined> {
    return this.http.get<IApplication>(this.applicationReadUrl + '/' + id)
      .pipe(
        tap(data => console.log('getApplication: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );

  }

  addApplication(applicationData: IApplication): Observable<IApplication> {
    const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<IApplication>(this.applicationWriteUrl, applicationData, httpHeaders)
      .pipe(
        tap(data => console.log('addApplication: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  updateApplication(applicationData: IApplication): Observable<IApplication> {
    const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<IApplication>(this.applicationWriteUrl + '/update' + '/' + applicationData.id, applicationData, httpHeaders)
      .pipe(
        tap(data => console.log('updateApplication: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  deleteApplication(id: number): Observable<IApplication> {
    return this.http.delete<IApplication>(this.applicationWriteUrl + '/delete' + '/' + id)
      .pipe(
        tap(data => console.log('All: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  showEnumValueApplicationType(value: number): string {

    return EnumApplicationTypes[value];
  }

  showEnumValueApplicationStatus(value: number): string {

    return EnumApplicationStatuses[value];
  }

  private handleError(err: HttpErrorResponse): Observable<never> {
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}

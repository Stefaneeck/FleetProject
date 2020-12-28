import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, from } from 'rxjs';
import { AuthService } from './auth.service';
import { Constants } from '../constants';
import { Router } from '@angular/router';
import { catchError } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})

/*
 *Right now, we only have one HTTP call to the Web API. But in a real-world application, we would have more than one repository file and for sure more HTTP calls.
 *With the solution, as we have it now, we have to make the same changes on each HTTP function all over the project and duplicate the same code.
 *To improve this solution, we are going to create a centralized place to inject the access token in the request and use that logic in our HTTP calls without the code repetition.
 */
export class AuthInterceptorService implements HttpInterceptor {

  constructor(private authService: AuthService, private router: Router) { }
  /*With this function, we can intercept any HTTP call, modify it, and then let it continue its journey to the Web API.
   * Here, we get the access token from the authentication service, create the header object, and then clone the request passing the headers parameter to it.
   * The req parameter contains the request that we can inspect and modify before we pass it out to the Web API.
   * Then, we have to handle our cloned request, convert it to promise, and wrap the entire functionality with the from() function from rxjs.
   *
   * Note: With this interceptor implementation, it will override any custom header you send in a request.
   * If you don’t have any custom headers in the request, you can use the code as-is.
   * But if you want to preserve a custom header and add the Authorization header as well, you should use :

    const headers = req.headers.set('Authorization', `Bearer ${token}`);
    instead of :
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

    This way, your custom headers won’t be overridden.
   */
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    /* Right now, our Angular application communicates only with a single Web API project, but maybe in the future, it may communicate with multiple Web Apis. Maybe some of those APIs will not require secure access to the resources since they are not protected.
     * That said, we don’t have to pass the access token to all the APIs, just to the one we have a token generated for (check with apiRoot which we set in Constants file).
     */

    //let headers = new HttpHeaders();
    let headers = new HttpHeaders({
      'Access-Control-Allow-Origin': '*'
    })
    if (req.url.startsWith(Constants.apiRoot)) {
      return from(
        this.authService.getAccessToken()
          .then(token => {

            //fix: 500 instead of 401 when token was null
            if (token !== null) {
              headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
            }
            const authRequest = req.clone({ headers });

            return next.handle(authRequest)
              /*We inject the router and use the catchError operator from the rxjs/operators location.
               * Inside the catchError operator, we check the error response and if the value of the status property is 401 or 403,
               * we redirect the user to the unauthorized page. Then we just throw an error message.
               */
              .pipe(
                catchError((err: HttpErrorResponse) => {
                  console.log("http response error");
                  ; console.log(err);
                  console.log(err.status);
                  //error status 0 when cors related error
                  if (err && (err.status === 401 || err.status === 403 || err.status === 0)) {
                    this.router.navigate(['/unauthorized']);
                  }
                  throw 'error in a request ' + err.status;
                })
              ).toPromise();
          })
      );
    }
    else {
      return next.handle(req);
    }
  }
}

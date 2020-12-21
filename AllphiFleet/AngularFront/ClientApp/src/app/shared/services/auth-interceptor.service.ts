import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Observable, from } from 'rxjs';
import { AuthService } from './auth.service';
import { Constants } from '../constants';

@Injectable({
  providedIn: 'root'
})

/*
 *Right now, we only have one HTTP call to the Web API. But in a real-world application, we would have more than one repository file and for sure more HTTP calls.
 *With the solution, as we have it now, we have to make the same changes on each HTTP function all over the project and duplicate the same code.
 *To improve this solution, we are going to create a centralized place to inject the access token in the request and use that logic in our HTTP calls without the code repetition.
 */
export class AuthInterceptorService implements HttpInterceptor {

  constructor(private authService: AuthService) { }
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
    if (req.url.startsWith(Constants.apiRoot)) {
      return from(
        this.authService.getAccessToken()
          .then(token => {
            const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
            const authRequest = req.clone({ headers });
            return next.handle(authRequest).toPromise();
          })
      );
    }
    else {
      return next.handle(req);
    }
  }
}

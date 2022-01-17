import { AuthService } from './../services/auth.service';
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

  /* Right now, unauthorized users can’t access the Companies or the Privacy page and also,
   * the authorized users must have an Admin role to access the Privacy page.
   * So, the security actions work great and the application redirects our users to the Unauthorized page.
   * But, for our security logic to take place, we have to send the HTTP request to the Web API, process the response,
   * and only then, we can redirect the user to the requested or unauthorized page.
     We can improve this logic a bit. We can prevent a request to even leave the client-side area if the user is unauthorized or if they have insufficient rights.
   */
export class AuthGuardService implements CanActivate {

  constructor(private authService: AuthService, private router: Router) {}

  /* implemented method from CanActivate interface (guard)
   * The method gets the instance of the ActivatedRouteSnapshot & RouterStateSnapshot. We can use this to get access to the route parameter, query parameter etc.
     The guard must return true/false or a UrlTree. The return value can be in the form of observable or a promise or a simple boolean value.
     A route can have more than one canActivate guard. If all guards returns true, navigation to the route will continue.
     If any one of the guard returns false, navigation will be cancelled.
     If any one of the guard returns a UrlTree, current navigation will be cancelled and a new navigation will be kicked off to the UrlTree returned from the guard.
   */ 
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const roles = route.data['roles'] as Array<string>;
    if (!roles) {
      return this.checkIsUserAuthenticated();
    }
    else {
      return this.checkForAdministrator();
    }
  }

  private checkIsUserAuthenticated() {
    return this.authService.isAuthenticated()
      .then(res => {
        return res ? true : this.redirectToUnauthorized();
      });
  }

  private checkForAdministrator() {
    return this.authService.checkIfUserIsAdmin()
      .then(res => {
        return res ? true : this.redirectToUnauthorized();
      });
  }

  private redirectToUnauthorized() {
    this.router.navigate(['/unauthorized']);
    return false;
  }
}

import { Injectable } from '@angular/core';
import { UserManager, User, UserManagerSettings } from 'oidc-client';
import { Constants } from '../constants';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private _userManager: UserManager;
  private _user: User;
  private _loginChangedSubject = new Subject<boolean>();
  public loginChanged = this._loginChangedSubject.asObservable();

  private get idpSettings(): UserManagerSettings {
    return {
      authority: Constants.idpAuthority,
      client_id: Constants.clientId,
      redirect_uri: `${Constants.clientRoot}/signin-callback`,
      scope: "openid profile api1.read",
      response_type: "code",
      post_logout_redirect_uri: `${Constants.clientRoot}/signout-callback`
    }
  }

  constructor() {
    this._userManager = new UserManager(this.idpSettings);
  }

  /*
   * In this function, we call the signinRedirect function from the UserManager class.
   * This function will redirect us to the authorization endpoint on the IDP server.
   * Additionally, the UserManager stores a user result in the session storage after a successful login action
   * and we can always retrieve that object and use all the information it contains.
   */
  public login = () => {
    return this._userManager.signinRedirect();
  }

  public isAuthenticated = (): Promise<boolean> => {
    return this._userManager.getUser()
      .then(user => {
        //As soon as the user’s status changes, we want to inform any component that needs that kind of information.
        if (this._user !== user) {
          this._loginChangedSubject.next(this.checkUser(user));
        }
        this._user = user;
        return this.checkUser(user);
      })
  }

  //check if user is not null and not expired
  private checkUser = (user: User): boolean => {
    return !!user && !user.expired;
  }

  /*
   * In this function, we call the signinRedirectCallback function that processes the response from the /authorization endpoint and returns a promise.
   * From that promise, we extract the user object and populate the _user property.
   * Additionally, we call the next function from the observable to inform any subscribed component
   * about the Angular authentication state change, and finally, return that user.
   */ 
  public finishLogin = (): Promise<User> => {
    return this._userManager.signinRedirectCallback()
      .then(user => {
        this._user = user;
        this._loginChangedSubject.next(this.checkUser(user));
        return user;
      })
  }

  public logout = () => {
    this._userManager.signoutRedirect();
  }

  public finishLogout = () => {
    this._user = null;
    return this._userManager.signoutRedirectCallback();
  }

  public getAccessToken = (): Promise<string> => {
    return this._userManager.getUser()
      .then(user => {
        return !!user && !user.expired ? user.access_token : null;
      })
  }
}

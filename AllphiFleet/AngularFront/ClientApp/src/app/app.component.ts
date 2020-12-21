import { Component, OnInit } from '@angular/core';
import { AuthService } from './shared/services/auth.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {

  /*
   * After the login action on the IDP side, the redirection happens back to the Angular application causing the Angular app to refresh itself (a fresh load of the application).
   * Modify the app.component file to check if the user is authenticated
   */
  title = 'app';
  public userAuthenticated = false;

  /*
   * In the ngOnInit function, we just call the isAuthenticated function from the AuthService file
   * and populate the userAuthenticated property with true or false values.
   * Also, we modify the constructor to react to the login change event.
   * Now, if we need it, we can use the userAuthenticated property to modify the app.component.html page
   * based on whether the user is authorized or not.
   */
  constructor(private _authService: AuthService) {
    this._authService.loginChanged
      .subscribe(userAuthenticated => {
        this.userAuthenticated = userAuthenticated;
      })
  }

  ngOnInit(): void {
    this._authService.isAuthenticated()
      .then(userAuthenticated => {
        this.userAuthenticated = userAuthenticated;
      })
  }
}

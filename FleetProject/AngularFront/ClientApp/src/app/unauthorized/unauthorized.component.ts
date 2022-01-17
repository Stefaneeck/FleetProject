import { Component, OnInit } from '@angular/core';
import { AuthService } from '../shared/services/auth.service';

@Component({
  selector: 'app-unauthorized',
  templateUrl: './unauthorized.component.html',
  styleUrls: ['./unauthorized.component.css']
})
export class UnauthorizedComponent implements OnInit {

  public isUserAuthenticated: boolean = false;

  constructor(private authService: AuthService) {
    //We subscribe to the loginChanged observable to check if the user is authenticated or not.
    this.authService.loginChanged
      .subscribe(res => {
        this.isUserAuthenticated = res;
      })
  }

  ngOnInit() {
    //We check the same thing in the ngOnInit function but by calling the isAuthenticated function.
    this.authService.isAuthenticated()
      .then(isAuth => {
        this.isUserAuthenticated = isAuth;
      })
  }

  public login = () => {
    this.authService.login();
  }
  public logout = () => {
    this.authService.logout();
  }

}

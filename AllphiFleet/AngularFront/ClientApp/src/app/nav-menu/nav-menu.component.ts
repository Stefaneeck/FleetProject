import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from '../shared/services/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  public isUserAuthenticated: boolean = false;
  public isUserAdmin: boolean = false;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.authService.loginChanged
      .subscribe(res => {
        //needed to display the correct link (login or logout)
        this.isUserAuthenticated = res;
        this.isAdmin();
      })
  }

  public login = () => {
    this.authService.login();
  }

  public logout = () => {
    this.authService.logout();
  }

  public isAdmin = () => {
    return this.authService.checkIfUserIsAdmin()
      .then(res => {
        this.isUserAdmin = res;
      })
  }

}

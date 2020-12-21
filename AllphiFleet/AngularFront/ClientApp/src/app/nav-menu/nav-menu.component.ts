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

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.authService.loginChanged
      .subscribe(res => {
        //needed to display the correct link (login or logout)
        this.isUserAuthenticated = res;
      })
  }

  public login = () => {
    this.authService.login();
  }

  public logout = () => {
    this.authService.logout();
  }

}

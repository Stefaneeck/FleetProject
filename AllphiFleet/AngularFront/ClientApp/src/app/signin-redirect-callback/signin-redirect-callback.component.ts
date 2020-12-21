import { Component, OnInit } from '@angular/core';
import { AuthService } from '../shared/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signin-redirect-callback',
  template: `<div></div>`
})
export class SigninRedirectCallbackComponent implements OnInit {

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {

    /*
     * In the ngOnInit function, we call the finishLogin function from the AuthService and just navigate the user to the home page.
     * We set the replaceUrl property to true because we want to remove this component from the navigation stack.
     */ 
    this.authService.finishLogin()
      .then(_ => {
        this.router.navigate(['/'], { replaceUrl: true });
      })
  }

}

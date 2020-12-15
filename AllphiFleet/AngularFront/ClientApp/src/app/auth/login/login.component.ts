import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { LoginDTO } from '../../domain/DTO/LoginDTO';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  errorMessage = "";
  jwToken: any | undefined;
  loginForm: any;

  constructor(private formBuilder: FormBuilder, private authService: AuthService,
    private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({

      Email: ['', [Validators.required]],
      Password: ['', [Validators.required]],
    });
  }

  validateLogin(loginDTO: LoginDTO): void {
    let loginDataFromForm = this.loginForm.value;

    if (this.loginForm.valid) {
      console.log("valid.");

      this.authService.validateLoginAndGetToken(loginDataFromForm).subscribe({

        //next: result => this.driver = result,
        error: err => {
          this.errorMessage = err;
          console.log(this.errorMessage);
        },
        complete: () => {
          this.router.navigate(['/driverlist']);
        }
      });
    }

    else {
      console.log("not valid");
    }

  }

}

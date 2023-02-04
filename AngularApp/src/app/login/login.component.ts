import { Component } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent {
  constructor(private auth: AuthService){

  }

  UserName: any = "";
  Password: any = "";

  login() {
    return this.auth.login({
      userName: this.UserName,
      password : this.Password,
    })
  }
}

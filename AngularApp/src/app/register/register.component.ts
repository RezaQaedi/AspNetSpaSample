import { Component } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  constructor(private auth: AuthService){

  }

  userName: any = "";
  password: any = "";
  confirmPassowrd: any = "";

  login() {
    return this.auth.regiser({
      userName: this.userName,
      password : this.password,
      confirmPassowrd : this.confirmPassowrd,
    })
  }
}

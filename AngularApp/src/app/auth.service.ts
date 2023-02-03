import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { 
    this.loadUser()
  }

  user:any = null;

  async loadUser() {
    const user = await firstValueFrom(
      this.http.get<any>("api/user")
    )

      if('user_id' in user){
        this.user = user
      }
    return user
  }

  login(loginForm:any){
    return this.http.post<any>("/api/login", loginForm, {withCredentials: true})
    .subscribe(_ => {
      this.loadUser()
    })
  }

  regiser(registreForm:any){
    return this.http.post<any>("/api/regiser", registreForm, {withCredentials: true})
    .subscribe(_ => {
      this.loadUser()
    })    
  }

  logout(){
    return this.http.get<any>("api/logout")
    .subscribe(_ => this.user = null)
  }
}

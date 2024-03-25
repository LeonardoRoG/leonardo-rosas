import { HttpClient } from '@angular/common/http';
import { Injectable, computed, inject, signal } from '@angular/core';
import { Router } from '@angular/router';
import { enviroment } from '../enviroments/enviroments';
import { User, UserLogin, UserRegister } from './interface';
import { Observable, map } from 'rxjs';
import * as jwt from 'jwt-decode';
import { AuthStatus } from './interface/auth-status.enum';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private http = inject(HttpClient);
  private router = inject(Router);
  private readonly url = enviroment.apiUrl;

  private _authStatus = signal<AuthStatus>(AuthStatus.checking);
  private _currentUser = signal<User | undefined>(undefined);

  public authStatus = computed(() => this._authStatus());
  public currentUser = computed(() => this._currentUser());


  register(newUser: UserRegister): Observable<any> {
    return this.http.post<any>(`${this.url}/account/register`, newUser);
  }

  login(userLogin: UserLogin): Observable<any> {
    return this.http.post<any>(`${this.url}/account/login`, userLogin).pipe(
      map(({ accessToken }) => {
        console.log(accessToken);
        this.router.navigateByUrl('/');
        this.setAuthentication(accessToken);
        return accessToken;
      })
    )
  }

  setAuthentication(token: string | null) {
    if (token) {
      localStorage.setItem('accessToken', token);

      const userResponse = jwt.jwtDecode(token) as User;
      console.log('userResponse: ', userResponse);

      this._authStatus.set(AuthStatus.authenticated);
      this._currentUser.set({
        name: userResponse.name,
        role: userResponse.role,
        exp: userResponse.exp
      });
    }
    console.log('señal computada: ', this.currentUser());
  }

  checkStatus() {
    const token = this.getToken();
    console.log('checkstatus: ', token);
    this.setAuthentication(token);
  }

  logout() {
    localStorage.removeItem('accessToken');
    this._authStatus.set(AuthStatus.notAuthenticated);
    this.router.navigateByUrl('/');
  }

  getToken(): string | null {
    return localStorage.getItem('accessToken');
  }
}

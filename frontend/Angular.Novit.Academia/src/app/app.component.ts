import { Component, OnInit, effect, inject } from '@angular/core';
import { AuthService } from './auth/auth.service';
import { Router } from '@angular/router';
import { User } from './auth/interface';
import { AuthStatus } from './auth/interface/auth-status.enum';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  private authService = inject(AuthService);
  private router = inject(Router);

  isAuthenticated: boolean = false;
  title = 'Housing';
  showFiller = false;

  currentUserLogin?: User;

  constructor() {

    //El effect es un detector de cambios de estados que trae Angular,
    //Si colocas un componente, o elemento, o señal, se encarga de escuchar sus cambios, como el useEffect() de React
    // En este caso al hacer una logica switch con this.authService.authStatus() empieza a escuchar la señal authStatus() cuando surge un cambio de estado
    // ejecuta el effect() y realiza la operacion
    const userChangeEffect = effect(() => {
      switch (this.authService.authStatus()) {
        case AuthStatus.authenticated:
          this.isAuthenticated = true;
          this.currentUserLogin = this.authService.currentUser();
          break;
        case AuthStatus.notAuthenticated:
          this.isAuthenticated = false;
          this.currentUserLogin = this.authService.currentUser();
          break;
        default:
          this.isAuthenticated = false;
          this.currentUserLogin = this.authService.currentUser();
          break;
      }
    });
  }

  ngOnInit(): void {
    this.authService.checkStatus();

    if (this.authService.authStatus() === AuthStatus.authenticated) {
      this.isAuthenticated = true;
      this.currentUserLogin = this.authService.currentUser();
    }
  }

  logout() {
    this.authService.logout();
    this.router.navigateByUrl('/auth');
  }
}

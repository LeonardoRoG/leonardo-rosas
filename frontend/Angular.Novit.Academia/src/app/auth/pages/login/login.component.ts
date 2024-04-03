import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../auth.service';
import { Router } from '@angular/router';
import { UserLogin } from '../../interface';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit{

  hide = true;
  private fb = inject(FormBuilder);
  private authService = inject(AuthService);
  private router = inject(Router);

  loginForm!: FormGroup;

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]]
    })    
  }

  login() {
    const newUsuario = this.loginForm.value as UserLogin

    this.authService.login(newUsuario)
      .subscribe({
        next: res => {
          this.router.navigateByUrl('/');
        },
        error: err => {
          console.error(err);
        }
      })
  }

}

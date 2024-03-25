import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductoComponent } from './producto/producto.component';
import { authGuard } from './auth/guard/auth.guard';
import { isNotAuthenticatedGuard } from './auth/guard/is-not-authenticated.guard';
import { redireccionGuard } from './auth/guard/redireccion.guard';

const routes: Routes = [
  {
    path: 'producto',
    canActivate: [authGuard],
    data: {roles: ['administrador', 'vendedor', 'comercial']},
    loadChildren: () => import('./producto/producto.module')
    .then(m => m.ProductoModule)
  },
  {
    path: 'reserva',
    canActivate: [authGuard],
    data: {roles: ['administrador', 'vendedor', 'comercial']},
    loadChildren: () => import('./reserva/reserva.module')
    .then(m => m.ReservaModule)
  },
  {
    path: 'auth',
    canActivate: [isNotAuthenticatedGuard],
    loadChildren: () => import('./auth/auth.module')
    .then(m => m.AuthModule)
  },
  // {
  //   path: '',
  //   canActivate: [redireccionGuard],
  //   component: ProductoComponent,
  // },
  // {
  //   path: '**',
  //   redirectTo: 'auth/login',
  // },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

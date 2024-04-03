import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuard } from './auth/guard/auth.guard';
import { isNotAuthenticatedGuard } from './auth/guard/is-not-authenticated.guard';
import { redireccionGuard } from './auth/guard/redireccion.guard';
import { ReservaListComponent } from './reserva/reserva-list/reserva-list.component';

const routes: Routes = [
  {
    path: 'producto',
    canActivate: [authGuard],
    data: {roles: ['vendedor']},
    loadChildren: () => import('./producto/producto.module')
    .then(m => m.ProductoModule)
  },
  {
    path: 'reserva',
    canActivate: [authGuard],
    data: {roles: ['vendedor', 'comercial']},
    loadChildren: () => import('./reserva/reserva.module')
    .then(m => m.ReservaModule)
  },
  {
    path: 'auth',
    canActivate: [isNotAuthenticatedGuard],
    loadChildren: () => import('./auth/auth.module')
    .then(m => m.AuthModule)
  },
  {
    path: '',
    canActivate: [redireccionGuard],
    component: ReservaListComponent,
  },
  {
    path: '**',
    redirectTo: 'auth/login',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

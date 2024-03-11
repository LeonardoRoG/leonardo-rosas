import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductoComponent } from './producto/producto.component';

const routes: Routes = [
  {
    path: 'producto',
    loadChildren: () => import('./producto/producto.module')
    .then(m => m.ProductoModule)
  },
  {
    path: 'reserva',
    loadChildren: () => import('./reserva/reserva.module')
    .then(m => m.ReservaModule)
  },
  {
    path: 'auth',
    loadChildren: () => import('./auth/auth.module')
    .then(m => m.AuthModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

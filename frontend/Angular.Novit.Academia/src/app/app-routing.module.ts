import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'productos',
    loadChildren: () => import('./producto/producto.module')
    .then(m => m.ProductoModule)
  },
  {
    path: 'reservas',
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

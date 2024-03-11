import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReservaComponent } from './reserva.component';
import { ReservaDetalleComponent } from './reserva-detalle/reserva-detalle.component';
import { NuevaReservaComponent } from './nueva-reserva/nueva-reserva.component';
import { IndexComponent } from './index/index.component';

export const routes: Routes = [
  {
    path: '',
    component: IndexComponent,
    children: [
      {
        path: 'reservas',
        component: ReservaComponent
      },
      {
        path: 'detalles',
        component: ReservaDetalleComponent
      },
      {
        path: 'nueva',
        component: NuevaReservaComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReservaRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NuevaReservaComponent } from './nueva-reserva/nueva-reserva.component';
import { IndexComponent } from './index/index.component';
import { ReservaListComponent } from './reserva-list/reserva-list.component';

export const routes: Routes = [
  {
    path: '',
    component: IndexComponent,
    children: [
      {
        path: 'reservas',
        component: ReservaListComponent
      },
      {
        path: 'nueva/:id',
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

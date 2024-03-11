import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReservaRoutingModule } from './reserva-routing';
import { ReservaComponent } from './reserva.component';
import { ReservaDetalleComponent } from './reserva-detalle/reserva-detalle.component';
import { NuevaReservaComponent } from './nueva-reserva/nueva-reserva.component';
import { IndexComponent } from './index/index.component';


@NgModule({
  declarations: [
    ReservaComponent,
    ReservaDetalleComponent,
    NuevaReservaComponent,
    IndexComponent
  ],
  imports: [
    CommonModule,
    ReservaRoutingModule
  ]
})
export class ReservaModule { }

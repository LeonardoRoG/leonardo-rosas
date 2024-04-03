import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReservaRoutingModule } from './reserva-routing';
import { NuevaReservaComponent } from './nueva-reserva/nueva-reserva.component';
import { IndexComponent } from './index/index.component';
import { ReservaListComponent } from './reserva-list/reserva-list.component';
import { MaterialModule } from '../shared/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { provideCharts, withDefaultRegisterables } from 'ng2-charts';
import { ChartsComponent } from './charts/charts.component';

@NgModule({
  declarations: [
    ReservaListComponent,
    NuevaReservaComponent,
    IndexComponent,
  ],
  imports: [
    CommonModule,
    ReservaRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    ChartsComponent
  ],
  providers: [
    provideCharts(withDefaultRegisterables())
  ]
})
export class ReservaModule { }

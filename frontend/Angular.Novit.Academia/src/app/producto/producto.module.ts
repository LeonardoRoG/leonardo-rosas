import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductoDetalleComponent } from './producto-detalle/producto-detalle.component';
import { NuevoProductoComponent } from './nuevo-producto/nuevo-producto.component';
import { ProductoComponent } from './producto.component';
import { RouterModule } from '@angular/router';
import { routes } from './producto-routing';
import { IndexComponent } from './index/index.component';
import { MaterialModule } from '../shared/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    ProductoDetalleComponent,
    NuevoProductoComponent,
    ProductoComponent,
    IndexComponent,
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MaterialModule,
    ReactiveFormsModule,
    FormsModule
  ],
  exports: [
    ProductoDetalleComponent,
    NuevoProductoComponent
  ]
})
export class ProductoModule { }

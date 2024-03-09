import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { routes } from './producto-routing';
import { ProductoDetalleComponent } from './producto-detalle/producto-detalle.component';
import { NuevoProductoComponent } from './nuevo-producto/nuevo-producto.component';
import { ProductoComponent } from './producto.component';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    ProductoDetalleComponent,
    NuevoProductoComponent,
    ProductoComponent,
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
  ],
  exports: [
    ProductoDetalleComponent,
    NuevoProductoComponent
  ]
})
export class ProductoModule { }

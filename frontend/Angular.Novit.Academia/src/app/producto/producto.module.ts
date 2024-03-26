import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductoDetalleComponent } from './producto-detalle/producto-detalle.component';
import { NuevoProductoComponent } from './nuevo-producto/nuevo-producto.component';
import { RouterModule } from '@angular/router';
import { routes } from './producto-routing';
import { IndexComponent } from './index/index.component';
import { MaterialModule } from '../shared/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductoEditComponent } from './producto-edit/producto-edit.component';
import { ProductoListComponent } from './producto-list/producto-list.component';

@NgModule({
  declarations: [
    ProductoDetalleComponent,
    NuevoProductoComponent,
    IndexComponent,
    ProductoEditComponent,
    ProductoListComponent,
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

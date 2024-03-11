import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductoComponent } from './producto.component';
import { ProductoDetalleComponent } from './producto-detalle/producto-detalle.component';
import { NuevoProductoComponent } from './nuevo-producto/nuevo-producto.component';
import { IndexComponent } from './index/index.component';

export const routes: Routes = [
  {
    path: '',
    component: IndexComponent,
    children: [
      {
        path: 'productos',
        component: ProductoComponent
      },
      {
        path: 'detalle',
        component: ProductoDetalleComponent
      },
      {
        path: 'nuevo',
        component: NuevoProductoComponent
      }
    ]
  }
];

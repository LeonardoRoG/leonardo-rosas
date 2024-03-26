import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductoDetalleComponent } from './producto-detalle/producto-detalle.component';
import { NuevoProductoComponent } from './nuevo-producto/nuevo-producto.component';
import { IndexComponent } from './index/index.component';
import { ProductoEditComponent } from './producto-edit/producto-edit.component';
import { ProductoListComponent } from './producto-list/producto-list.component';

export const routes: Routes = [
  {
    path: '',
    component: IndexComponent,
    children: [
      {
        path: 'productos',
        component: ProductoListComponent
      },
      {
        path: 'detalle/:id',
        component: ProductoDetalleComponent
      },
      {
        path: 'nuevo',
        component: NuevoProductoComponent
      },
      {
        path: 'editar/:id',
        component: ProductoEditComponent
      }
    ]
  }
];

import { Injectable } from '@angular/core';
import { EEstado, IProducto } from './interface/producto.interface';
import { max } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  title: string = 'Sección productos'

  protected productos: IProducto[] = [
    {
      id: 1,
      codigo: 'FBR0223',
      barrio: 'San martin',
      precio: 12000,
      urlImagen: '',
      estado: EEstado.Disponible,
    },
    {
      id: 2,
      codigo: 'MRZ1323',
      barrio: 'Belgrano',
      precio: 9000,
      urlImagen: '',
      estado: EEstado.Disponible,
    },
    {
      id: 3,
      codigo: 'ABR2223',
      barrio: 'San Miguel',
      precio: 13000,
      urlImagen: '',
      estado: EEstado.Disponible,
    },
    {
      id: 4,
      codigo: 'AGS1220',
      barrio: 'Cadenas',
      precio: 22000,
      urlImagen: '',
      estado: EEstado.Disponible,
    },
    {
      id: 5,
      codigo: 'DMB1422',
      barrio: 'Palermo',
      precio: 54000,
      urlImagen: '',
      estado: EEstado.Disponible,
    }
  ];

  obtenerProductos(): IProducto[]{
    return this.productos;
  }

  obtenerProductoPorId(id: number): IProducto | undefined{
    return this.productos.find((producto) => producto.id === id);
  } 

}

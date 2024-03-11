import { Component, inject } from '@angular/core';
import { IProducto } from './interface/producto.interface';
import { ProductoService } from './producto.service';

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrl: './producto.component.css'
})
export class ProductoComponent {

  title: string = 'Productos'

  productosList: IProducto[] = [];
  productosService: ProductoService = inject(ProductoService);

  constructor(){
    this.productosList = this.productosService.obtenerProductos();
  }

}

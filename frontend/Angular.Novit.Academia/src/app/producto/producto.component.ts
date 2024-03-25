import { Component, OnInit, inject } from '@angular/core';
import { IProducto } from './interface/producto.interface';
import { ProductoService } from './producto.service';

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrl: './producto.component.css'
})
export class ProductoComponent implements OnInit{
  
  title: string = 'Productos'
  private productoService = inject(ProductoService);
  
  productosList: IProducto[] = [];
  
  ngOnInit(): void {
    this.productoService.getProductos().subscribe({
      next: (productos) => {
        this.productosList = productos;
      },
      error: err => {
        console.log(err);
      }
    });
  }

  mostrarEstado(estado: number){
    if (estado == 0) {
      return 'Disponible';
    }
    else if (estado == 1){
      return 'Reservado';
    }
    else if (estado == 2){
      return 'Vendido';
    }
    return;
  }
}

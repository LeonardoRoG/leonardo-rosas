import { Component, OnInit, inject } from '@angular/core';
import { Router } from '@angular/router';
import { IProducto } from '../interface/producto.interface';
import { ProductoService } from '../producto.service';

@Component({
  selector: 'app-producto-list',
  templateUrl: './producto-list.component.html',
  styleUrl: './producto-list.component.css'
})
export class ProductoListComponent implements OnInit{

  title: string = 'Productos'
  private productoService = inject(ProductoService);
  private router = inject(Router);
  
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

  eliminarProducto(id: number){
    this.productoService.deleteProducto(id).subscribe({
      next: response => {
        console.log('Producto eliminado: ', id);
      },
      error: err => {
        console.error(err);
      },
      complete: () => {
        this.router.navigateByUrl('/producto/productos')
      }
    });
  }

}
